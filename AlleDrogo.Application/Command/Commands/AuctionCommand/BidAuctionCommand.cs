using MediatR;
using System;

namespace AlleDrogo.Application.Command.AuctionCommand
{
    public class BidAuctionCommand : IRequest
    {
        public int AuctionId { get; set; }

        public decimal BidAmount { get; set; }

        public DateTime BiddingTime { get; set; }

        public string Username { get; set; }
    }
}
