using BusinessAccessLayer.Abstraction;
using BusinessAccessLayer.Settings;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;

namespace BusinessAccessLayer.Implementation;

public class FirebaseStorageService : IFirebaseStorageService
{
    #region Properties

    private readonly StorageClient _storageClient;
    private readonly string _bucketName;

    #endregion Properties

    #region Constructor

    public FirebaseStorageService(StorageClient storageClient,
        FirebaseSetting firebaseSetting)
    {
        _storageClient = storageClient;
        _bucketName = firebaseSetting.BucketName;
    }

    #endregion Constructor

    #region Interface methods

    public async Task<string?> UploadFile(IFormFile file,
        string folder,
        CancellationToken cancellationToken = default)
    {
        if (file is null || file.Length == 0) return null;

        Guid fileName = Guid.NewGuid();

        using (var stream = file.OpenReadStream())
        {
            string objectName = $"{folder}/{fileName}";
            await _storageClient.UploadObjectAsync(_bucketName,
                objectName,
                file.ContentType,
                stream,
                cancellationToken: cancellationToken);
        }

        string url = $"https://firebasestorage.googleapis.com/v0/b/{_bucketName}/o/files%2F{fileName}?alt=media";

        return url;
    }

    #endregion Interface methods

    #region Helper methods
    #endregion
}