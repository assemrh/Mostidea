using Microsoft.AspNetCore.Http;

namespace Mostidea.Domain.Interfaces
{
    public interface IFileService
    {
        Task SaveUploadedFile(IFormFile file);
        Task<IReadOnlyList<FileModel>> GetUploadedFiles();
        public bool ValidateFile(IFormFile file);
    }
}
