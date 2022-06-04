using AlleDrogo.Domain.Entities.AppUser;
using AlleDrogo.Domain.Entities.Auction;
using MediatR;
using System.Collections.Generic;

namespace AlleDrogo.Application.Query.Queries.AuctionQueries
{
    public class GetActiveAuctionsByUserQuery : IRequest<IEnumerable<Auction>>
    {
        public string UserName { get; set; }
    }
}
