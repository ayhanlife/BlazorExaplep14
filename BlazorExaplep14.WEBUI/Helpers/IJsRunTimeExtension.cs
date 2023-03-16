using Microsoft.JSInterop;

namespace BlazorExaplep14.WEBUI.Helpers
{
    public static class IJsRunTimeExtension
    {
        public static async ValueTask ToastSuccess(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("DisplayTostr", "success", Message);
        }

        public static async ValueTask ToastError(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("DisplayTostr", "error", Message);
        }
    }
}
