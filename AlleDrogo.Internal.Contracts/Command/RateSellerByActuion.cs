using AlleDrogo.Internal.Contracts.Models;
using MediatR;

namespace AlleDrogo.Internal.Contracts.Command
{
    public class RateSellerByAuction : IRequest<int>
    {
        public RateSellerModel RateSeller { get; set; }
    }
}
