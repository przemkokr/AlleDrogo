namespace AlleDrogo.Internal.Contracts.Models
{
    public class AuctionItemModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CategoryEnum Category { get; set; }

        public bool IsNew { get; set; }
    }
}
