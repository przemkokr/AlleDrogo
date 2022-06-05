using AlleDrogo.Domain.Entities.Auctions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlleDrogo.Persistance.Mappings.Auctions
{
    public class RatingMap
    {
        public RatingMap(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.EvaluatedUser);
        }
    }
}
