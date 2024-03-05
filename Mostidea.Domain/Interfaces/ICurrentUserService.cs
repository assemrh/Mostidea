using Mostidea.Domain.Entities;

namespace Mostidea.Domain.Interfaces
{
    public interface ICurrentUserService
    {
        Task<ApplicationUser?> GetCurrentUserAsync();
    }
}
