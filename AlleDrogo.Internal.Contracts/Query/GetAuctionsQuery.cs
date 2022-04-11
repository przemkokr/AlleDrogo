using AlleDrogo.Domain.Entities.Auction;
using MediatR;
using System.Collections.Generic;

namespace AlleDrogo.Internal.Contracts.Query
{
    public class GetAuctionsQuery : IRequest<IEnumerable<Auction>>
    {
    }
}
