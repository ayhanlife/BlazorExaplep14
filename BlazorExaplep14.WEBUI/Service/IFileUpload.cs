using Microsoft.AspNetCore.Components.Forms;

namespace BlazorExaplep14.WEBUI.Service
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
    }
}
