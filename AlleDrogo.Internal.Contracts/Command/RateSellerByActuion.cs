using AlleDrogo.Internal.Contracts.Models;
using MediatR;

namespace AlleDrogo.Internal.Contracts.Command
{
    public class RateSellerByAuctionCommand : IRequest<int>
    {
        public RateSellerModel RateSeller { get; set; }
    }
}
