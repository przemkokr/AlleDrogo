using AlleDrogo.Internal.Contracts.Models;
using MediatR;
using System;

namespace AlleDrogo.Internal.Contracts.Command
{
    public class AddAuctionCommand : IRequest<AddAuctionResult>
    {
        public AuctionItemModel Item { get; set; }

        public string Username { get; set; }

        public string Title { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public bool IsBuyNow { get; set; }

        public decimal? BuyNowValue { get; set; }

        public decimal InitialValue { get; set; }
    }
}
