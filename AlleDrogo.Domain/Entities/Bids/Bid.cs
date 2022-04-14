using AlleDrogo.Domain.Entities.Base;
using System;

namespace AlleDrogo.Domain.Entities.Bids
{
    public class Bid : EntityBase
    {
        protected Bid() { }

        public Bid(Auction.Auction auction, int userId, decimal bidAmount, DateTime biddingTime)
        {
            Auction = auction;
            UserId = userId;
            BidAmount = bidAmount;
            BiddingTime = biddingTime;
        }

        public Auction.Auction Auction { get; protected set; }

        public int UserId { get; protected set; }

        public decimal BidAmount { get; protected set; }

        public DateTime BiddingTime { get; protected set; }

    }
}
