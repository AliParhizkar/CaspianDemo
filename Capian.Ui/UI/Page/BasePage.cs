using Caspian.Common;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using Caspian.Common.Extension;
using Microsoft.AspNetCore.Components;
using System.Reflection;
using Caspian.Common.Service;

namespace Caspian.UI
{
    public class BasePage: OwningComponentBase
    {
        public static bool IsStarted { get; set; }

        [Inject]
        public MyContext Context { get; set; }

        string message;
        protected ConfirmMessage ConfirmMessage;

        [Inject]
        protected IJSRuntime jsRuntime { get; set; }
        
        public void ShowMessage(string msg)
        {
            message = msg;
        }

        public async Task<bool> Confirm(string message)
        {
            return await ConfirmMessage.Confirm(message);
        }

        protected override void OnInitialized()
        {
            foreach(var info in GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                if (info.GetCustomAttribute<InjectAttribute>() != null)
                {
                    var  service = info.GetValue(this) as IEntity;
                    if (service != null)
                        service.Context = Context;
                }
            }
            base.OnInitialized();
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (message.HasValue())
            {
                await jsRuntime.InvokeVoidAsync("$.telerik.showMessage", message);
                message = null;
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
