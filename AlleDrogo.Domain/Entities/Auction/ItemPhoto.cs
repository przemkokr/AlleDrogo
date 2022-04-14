using AlleDrogo.Domain.Entities.Base;

namespace AlleDrogo.Domain.Entities.Auction
{
    public class ItemPhoto : EntityBase
    {
        protected ItemPhoto() { }

        public ItemPhoto(byte[] bytes, string extension, string description, bool isMain, AuctionItem auctionItem)
        {
            Bytes = bytes;
            Extension = extension;
            Description = description;
            IsMain = isMain;
            AuctionItem = auctionItem;
        }

        public byte[] Bytes { get; protected set; }

        public string Extension { get; protected set; }

        public string Description { get; protected set; }

        public bool IsMain { get; protected set; }

        public AuctionItem AuctionItem { get; protected set; }

        public void SetAsMain()
        {
            IsMain = true;
        }
    }
}
