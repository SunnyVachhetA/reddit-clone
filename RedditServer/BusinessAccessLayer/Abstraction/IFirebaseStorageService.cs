using Microsoft.AspNetCore.Http;

namespace BusinessAccessLayer.Abstraction;
public interface IFirebaseStorageService
{
    Task<string?> UploadFile(IFormFile file, string folder, CancellationToken cancellationToken = default);
}
