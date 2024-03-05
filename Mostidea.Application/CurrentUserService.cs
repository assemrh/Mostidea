using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Mostidea.Domain.Entities;
using Mostidea.Domain.Interfaces;
using System.Security.Claims;

namespace Mostidea.Application
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<ApplicationUser?> GetCurrentUserAsync()
        {
            ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;
            return await _userManager.GetUserAsync(currentUser)  ;
        }
    }
}
