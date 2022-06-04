using AlleDrogo.Internal.Contracts.Models;
using MediatR;
using System;

namespace AlleDrogo.Internal.Contracts.Command
{
    public class AddAuctionCommand : IRequest<AddAuctionResult>
    {
        public AuctionItemModel Item { get; protected set; }

        public string Username { get; set; }

        public string Title { get; protected set; }

        public DateTime EndDate { get; protected set; }

        public string Description { get; protected set; }

        public bool IsBuyNow { get; protected set; }

        public decimal? BuyNowValue { get; protected set; }
    }
}
