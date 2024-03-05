using System.Linq.Expressions;

namespace Mostidea.Domain.Specifications
{
    public class FilesWithUsersSpecification : BaseSpecifcation<FileModel>
    {
        public FilesWithUsersSpecification() : base()
        {
            AddInclude(x => x.ApplicationUser);
        }
    }
}
