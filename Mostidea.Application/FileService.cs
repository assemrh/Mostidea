using Microsoft.AspNetCore.Http;
using Mostidea.Domain;
using Mostidea.Domain.Interfaces;
using Mostidea.Domain.Specifications;

namespace Mostidea.Application
{
    public class FileService : IFileService
    {
        private readonly IGenericRepository<FileModel> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;
        private readonly string[] AllowedExtensions = { ".txt", ".pdf", ".doc", ".docx", ".jpg" , ".png", ".jpeg" }; 

        public FileService(
            IGenericRepository<FileModel> repository,
            IUnitOfWork unitOfWork
,
            ICurrentUserService currentUser)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<IReadOnlyList<FileModel>> GetUploadedFiles()
        {
            return await _repository.ListAsync(new FilesWithUsersSpecification());
        }

        public async Task SaveUploadedFile(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var dirPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            var filePath = Path.Combine(dirPath, fileName);

            if (!Directory.Exists(Path.Combine(dirPath)))
            {
                Directory.CreateDirectory(dirPath);
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            var user = await _currentUser.GetCurrentUserAsync();
            var newFile = new FileModel
            {
                FileName = fileName,
                FileSize = file.Length,
                UploadDate = DateTime.Now,
                Path = filePath,
                ApplicationUserId = user?.Id ?? Guid.Empty,
            };

            _repository.Add(newFile);

            await _unitOfWork.Complete();
        }
        public bool ValidateFile(IFormFile file)
        {
            if (file == null)
            {
                return false;
            }

            var fileExtension = Path.GetExtension(file.FileName);

            if (!AllowedExtensions.Contains(fileExtension.ToLower()))
            {
                return false;
            }

            return true;
        }
    }
}
