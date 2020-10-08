using System;
using FluentValidation;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation.Internal;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Caspian.UI
{
    public class CaspianValidationValidator: ComponentBase, IControlFocuseValidation
    {
        [CascadingParameter]
        private EditContext EditContext { get; set; }

        [Parameter]
        public Type ValidatorType { get; set; }

        [Parameter]
        public bool OnlyValidateOnSubmit { get; set; }

        IValidator Validator;
        ValidationMessageStore ValidationMessageStore;

        [Inject]
        IServiceProvider ServiceProvider { get; set; }

        public bool IsFirstInvalidControl { get; set; }

        private void ValidatorTypeChanged()
        {
            Validator = (IValidator)ServiceProvider.GetService(ValidatorType);
            //Validator.Validate(EditContext.Model);
        }

        private void HookUpEditContextEvents()
        {
            EditContext.OnValidationRequested += ValidationRequested;
            if (!OnlyValidateOnSubmit)
                EditContext.OnFieldChanged += FieldChanged;
        }

        async void FieldChanged(object sender, FieldChangedEventArgs args)
        {
            ValidationMessageStore.Clear();
            var result = await Validator.ValidateAsync(new ValidationContext(EditContext.Model, 
                new PropertyChain(), new RulesetValidatorSelector("default")));
            
            AddValidationResult(EditContext.Model, result);
        }

        async void ValidationRequested(object sender, ValidationRequestedEventArgs args)
        {
            ValidationMessageStore.Clear();
            var result = await Validator.ValidateAsync(new ValidationContext(EditContext.Model));
                        
            AddValidationResult(EditContext.Model, result);
        }

        void AddValidationResult(object model, ValidationResult validationResult)
        {
            var list = new List<int>();
            foreach (ValidationFailure error in validationResult.Errors)
            {
                //var index = Convert.ToInt32(error.FormattedMessagePlaceholderValues["CollectionIndex"]);
                var propertyName = error.PropertyName;
                FieldIdentifier fieldIdentifier = default;
                //if (propertyName.Contains('['))
                //{
                //    var array = propertyName.Split('[', ']');
                //    var index = Convert.ToInt32(array[1]);
                //    var collection = model.GetType().GetProperty(array[0]).GetValue(model) as IEnumerable;
                //    var data = collection.ToDynamicArray()[index];
                //    fieldIdentifier = new FieldIdentifier(data, error.PropertyName);
                //}
                //else
                    fieldIdentifier = new FieldIdentifier(model, error.PropertyName);
                ValidationMessageStore.Add(fieldIdentifier, error.ErrorMessage);
            }
            EditContext.NotifyValidationStateChanged();
        }

        private void EditContextChanged()
        {
            ValidationMessageStore = new ValidationMessageStore(EditContext);
            HookUpEditContextEvents();
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            //Keep a reference to the original values so we can check if they have changed
            var previousEditContext = EditContext;
            
            var previousValidatorType = ValidatorType;
            await base.SetParametersAsync(parameters);
            if (EditContext == null)
                throw new NullReferenceException($"{nameof(CaspianValidationValidator)} must be placed within an CaspianForm");
            if (ValidatorType == null)
                throw new NullReferenceException($"{nameof(ValidatorType)} must be specified.");
            if (!typeof(IValidator).IsAssignableFrom(ValidatorType))
                throw new ArgumentException($"{ValidatorType.Name} must implement {typeof(IValidator).FullName}");
            if (ValidatorType != previousValidatorType)
                ValidatorTypeChanged();
            // If the EditForm.Model changes then we get a new EditContext
            // and need to hook it up
            if (EditContext != previousEditContext)
                EditContextChanged();
        }
    }
}
