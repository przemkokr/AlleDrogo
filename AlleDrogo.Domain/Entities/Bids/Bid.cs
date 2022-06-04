using AlleDrogo.Domain.Entities.AppUser;
using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Domain.Entities.Base;
using System;

namespace AlleDrogo.Domain.Entities.Bids
{
    public class Bid : EntityBase
    {
        protected Bid() { }

        public Bid(Auction auction, ApplicationUser user, decimal bidAmount, DateTime biddingTime)
        {
            Auction = auction;
            User = user;
            BidAmount = bidAmount;
            BiddingTime = biddingTime;
        }

        public Auction Auction { get; protected set; }

        public ApplicationUser User { get; protected set; }

        public decimal BidAmount { get; protected set; }

        public DateTime BiddingTime { get; protected set; }

    }
}
