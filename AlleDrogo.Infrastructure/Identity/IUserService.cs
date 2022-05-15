using AlleDrogo.Domain.Entities.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlleDrogo.Infrastructure.Identity
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUser(string identity);
    }
}
