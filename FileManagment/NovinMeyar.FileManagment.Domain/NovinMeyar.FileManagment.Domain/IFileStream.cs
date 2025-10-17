using Microsoft.AspNetCore.Http;

namespace NovinMeyar.FileManagment.Domain
{
    public interface IFileStream
    {
        IFormFile Photo { get; set; }
        string Tag { get; set; }
        string UserCreatorName { get; set; }
    }
}
