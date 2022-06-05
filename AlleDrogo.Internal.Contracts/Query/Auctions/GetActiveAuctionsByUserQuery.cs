using AlleDrogo.Domain.Entities.Auctions;
using MediatR;
using System.Collections.Generic;

namespace AlleDrogo.Internal.Contracts.Query.Auctions
{
    public class GetActiveAuctionsByUserQuery : IRequest<IEnumerable<Auction>>
    {
        public string UserName { get; set; }
    }
}
