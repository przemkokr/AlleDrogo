using AlleDrogo.Domain.Entities.Auctions;
using MediatR;
using System.Collections.Generic;

namespace AlleDrogo.Internal.Contracts.Query.Auctions
{
    public class GetFinishedAuctionsByWinner : IRequest<IEnumerable<Auction>>
    {
        public string UserName { get; set; }
    }
}
