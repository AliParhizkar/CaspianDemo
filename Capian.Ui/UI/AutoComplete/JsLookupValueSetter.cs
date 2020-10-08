using Microsoft.JSInterop;

namespace Caspian.UI
{
    public class JsLookupValueSetter
    {
        private readonly IAutoCompleteValueInitializer Lookup;
        public JsLookupValueSetter(IAutoCompleteValueInitializer lookup)
        {
            Lookup = lookup;
        }

        [JSInvokable]
        public void UpdateSearchValue(string text)
        {
            //Lookup.SetSearchStringValue(text);
        }

        [JSInvokable]
        public void UpdateValue(int value)
        {
            var info = Lookup.GetType().GetProperty("ValueChanged");
            var valueChanged = info.GetValue(Lookup);
            var method = valueChanged.GetType().GetMethod("InvokeAsync");
            method.Invoke(valueChanged, new object[] { value });
        }
    }
}
