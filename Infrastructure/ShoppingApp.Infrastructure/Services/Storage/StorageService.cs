using Microsoft.AspNetCore.Http;
using ShoppingApp.Application.Abstractions.Storage;

namespace ShoppingApp.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        =>_storage.UploadAsync(pathOrContainerName, files);

        public Task DeleteAsync(string pathOrContainerName, string fileName)
         => _storage.DeleteAsync(pathOrContainerName, fileName);

        public List<string> GetFiles(string pathOrContainerName)
            => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
        =>_storage.HasFile(pathOrContainerName, fileName);

        public string StorageName { get=>_storage.GetType().Name; }
    }
}
