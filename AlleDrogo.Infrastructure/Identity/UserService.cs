using AlleDrogo.Domain.Entities.AppUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlleDrogo.Infrastructure.Identity
{
    public class UserService : IUserService
    {

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> GetUser(string identity)
        {
            var user = await userManager.FindByEmailAsync(identity);
            return user;
        }
    }
}
