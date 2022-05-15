using AlleDrogo.Domain.Entities.Auction;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlleDrogo.Persistance.Mappings.Auctions
{
    public class ItemPhotoMap
    {
        public ItemPhotoMap(EntityTypeBuilder<ItemPhoto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.AuctionItem);

        }
    }
}
