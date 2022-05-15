using AlleDrogo.Domain.Entities.Base;
using AlleDrogo.Domain.Entities.Bids;
using System;
using System.Collections.Generic;

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
            bool isBuyNow,
            bool isSold)
        {
            Title = title;
            Item = item;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            CurrentValue = currentValue;
            IsBuyNow = isBuyNow;
            IsSold = isSold;
        }

        public string Title { get; protected set; }

        public AuctionItem Item { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public DateTime EndDate { get; protected set; }

        public string Description { get; protected set; }

        public decimal CurrentValue { get; protected set; }

        public bool IsBuyNow { get; protected set; }

        public bool IsSold { get; protected set; }

        public decimal? BuyNowValue { get; protected set; }

        public ICollection<Bid> Bids { get; protected set; }

        public void SetBuyNowValue(decimal buyNowValue)
        {
            BuyNowValue = buyNowValue;
        }

        public void AddBid(Bid bid)
        {
            Bids.Add(bid);
            CurrentValue = bid.BidAmount;
        }

        public void SetSold()
        {
            IsSold = true;
        }
    }
}
