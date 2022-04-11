using AlleDrogo.Domain.Entities.Base;
using System;

namespace AlleDrogo.Domain.Entities.Auction
{
    public class Auction : EntityBase
    {
        protected Auction() { }

        public Auction(
            string title, 
            AuctionItem item, 
            DateTime startDate, 
            DateTime endDate, 
            string description, 
            decimal currentValue, 
            bool isBuyNow)
        {
            Title = title;
            Item = item;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            CurrentValue = currentValue;
            IsBuyNow = isBuyNow;
        }

        public string Title { get; protected set; }

        public AuctionItem Item { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public DateTime EndDate { get; protected set; }

        public string Description { get; protected set; }

        public decimal CurrentValue { get; protected set; }

        public bool IsBuyNow { get; protected set; }

        public decimal? BuyNowValue { get; protected set; }

        public void SetBuyNowValue(decimal buyNowValue)
        {
            BuyNowValue = buyNowValue;
        }
    }
}
