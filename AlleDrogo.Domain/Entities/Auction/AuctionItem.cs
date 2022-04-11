using AlleDrogo.Domain.Entities.Base;

namespace AlleDrogo.Domain.Entities.Auction
{
    public class AuctionItem : EntityBase
    {
        protected AuctionItem() { }

        public AuctionItem(string name, string description, string category, bool isNew)
        {
            Name = name;
            Description = description;
            Category = category;
            IsNew = isNew;
        }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public string Category { get; protected set; }

        public bool IsNew { get; protected set; }

        public virtual Auction Auction { get; protected set; }

        public int AuctionId { get; protected set; }
    }
}
