using AlleDrogo.Domain.Entities.Auction;

namespace AlleDrogo.Internal.Contracts.Models
{
    public class AuctionItemModel
    {
        public AuctionItemModel(string name, CategoryModel category, string description)
        {
            Name = name;
            Description = description;
            Category = category;
        }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public CategoryModel Category { get; protected set; }


    }
}
