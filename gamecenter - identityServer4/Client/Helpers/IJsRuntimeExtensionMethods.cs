using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace gamecenter.Client.Helpers
{
    public static class IJSRuntimeExensionMethods
    {
        public static async ValueTask InitializeInactivityTimer<T>(this IJSRuntime js, DotNetObjectReference<T> dotNetObjectReference) where T : class
        {
            await js.InvokeVoidAsync("initalizeInactivityTimer", dotNetObjectReference);
        }
        
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string msg)
        {
            await js.InvokeVoidAsync("console.log", "example");
            return await js.InvokeAsync<bool>("confirm", msg);
        }
    }
}