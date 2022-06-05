using AlleDrogo.Domain.Entities.Auction;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlleDrogo.Persistance.Mappings.Auctions
{
    public class RatingMapper
    {
        public RatingMapper(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.EvaluatedUser);
        }
    }
}
