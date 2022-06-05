using AlleDrogo.Domain.Entities.AppUser;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlleDrogo.Persistance.Mappings.Auctions
{
    public class ApplicationUserMap
    {
        public ApplicationUserMap(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.ListOfRatings).WithOne(x => x.EvaluatedUser);
            builder.Navigation(x => x.ListOfRatings).AutoInclude();
        }
    }
}
