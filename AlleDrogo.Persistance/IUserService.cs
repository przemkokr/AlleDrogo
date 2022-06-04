using AlleDrogo.Domain.Entities.AppUser;
using System.Threading.Tasks;

namespace AlleDrogo.Persistance
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUser(string identity);
    }
}
