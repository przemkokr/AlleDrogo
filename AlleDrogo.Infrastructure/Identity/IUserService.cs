using AlleDrogo.Domain.Entities.AppUser;
using System.Threading.Tasks;

namespace AlleDrogo.Infrastructure.Identity
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUser(string identity);
    }
}
