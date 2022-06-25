using AlleDrogo.Domain.Entities.Auctions;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlleDrogo.Internal.Contracts.Query.Auctions
{
    public class UserAuctionsQueryFactory
    {
        public static IRequest<IEnumerable<Auction>> CreateQuery(QueryType queryType, string username)
        {
            if (queryType is QueryType.ActiveByUser)
            {
                return new GetActiveAuctionsByUserQuery() { UserName = username };
            }
            else if (queryType is QueryType.WonByUser)
            {
                return new GetFinishedAuctionsByWinner() { UserName = username };
            }
            else
            {
                throw new ValidationException("Nieobsługiwany typ.");
            }
        }
    }
}
