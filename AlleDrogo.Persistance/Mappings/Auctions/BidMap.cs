using AlleDrogo.Domain.Entities.Bids;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlleDrogo.Persistance.Mappings.Auctions
{
    public class BidMap
    {
        public BidMap(EntityTypeBuilder<Bid> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasOne(b => b.Auction).WithMany(a => a.Bids);
            builder.HasOne(b => b.User);
        }
    }
}
