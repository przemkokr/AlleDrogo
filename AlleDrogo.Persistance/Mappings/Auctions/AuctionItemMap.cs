using AlleDrogo.Domain.Entities.Auction;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlleDrogo.Persistance.Mappings.Auctions
{
    public class AuctionItemMap
    {
        public AuctionItemMap(EntityTypeBuilder<AuctionItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Auction).WithOne(a => a.Item);
            builder.HasMany(x => x.Photos).WithOne(a => a.AuctionItem);
            //builder.Property(x => x.Category).HasConversion<string>();
        }
    }
}
