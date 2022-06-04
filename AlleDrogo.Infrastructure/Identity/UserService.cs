using AlleDrogo.Domain.Entities.AppUser;
using AlleDrogo.Persistance;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AlleDrogo.Infrastructure.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> GetUser(string identity)
        {
            var user = await userManager.FindByEmailAsync(identity);
            return user;
        }
    }
}
