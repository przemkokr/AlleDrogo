using AlleDrogo.Domain.Entities.Auction;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlleDrogo.Persistance.Mappings.Auctions
{
    public class AuctionMap
    {
        public AuctionMap(EntityTypeBuilder<Auction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(i => i.Item).WithOne(a => a.Auction);
            builder.Navigation(a => a.Item).AutoInclude();
        }
    }
}
