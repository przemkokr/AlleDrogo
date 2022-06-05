using AlleDrogo.Domain.Entities.Auctions;
using MediatR;
using System.Collections.Generic;

namespace AlleDrogo.Internal.Contracts.Query.Auctions
{
    public class GetAuctionsQuery : IRequest<IEnumerable<Auction>>
    {
    }
}
