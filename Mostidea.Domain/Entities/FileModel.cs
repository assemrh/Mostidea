using Mostidea.Domain.Entities;

namespace Mostidea.Domain;

public class FileModel : BaseEntity
{
    public string Path { get; set; }

    public string FileName { get; set; }
    public long FileSize { get; set; }
    public DateTime UploadDate { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public Guid ApplicationUserId { get; set; }
}