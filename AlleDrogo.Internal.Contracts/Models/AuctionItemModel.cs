namespace AlleDrogo.Internal.Contracts.Models
{
    public class AuctionItemModel
    {
        public AuctionItemModel(string name, CategoryEnum category, string description)
        {
            Name = name;
            Description = description;
            Category = category;
        }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public CategoryEnum Category { get; protected set; }


    }
}
