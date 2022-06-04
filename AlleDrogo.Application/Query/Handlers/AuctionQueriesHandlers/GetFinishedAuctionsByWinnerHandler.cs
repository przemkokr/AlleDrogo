using AlleDrogo.Application.Query.Queries.AuctionQueries;
using AlleDrogo.Domain.Entities.Auction;
using AlleDrogo.Persistance;
using AlleDrogo.Persistance.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlleDrogo.Application.Query.Handlers.AuctionQueriesHandlers
{
    public class GetFinishedAuctionsByWinnerHandler : IRequestHandler<GetFinishedAuctionsByWinner, IEnumerable<Auction>>
    {
        private readonly IRepository<Auction> _auctionRepository;
        private readonly IUserService _userService;

        public GetFinishedAuctionsByWinnerHandler(IRepository<Auction> auctionRepository, IUserService userService)
        {
            this._auctionRepository = auctionRepository;
            this._userService = userService;
        }
        public async Task<IEnumerable<Auction>> Handle(GetFinishedAuctionsByWinner request, CancellationToken cancellationToken)
        {
            var auctions = _auctionRepository.GetAll().Where(a => a.EndDate > DateTime.Now);
            var user = await _userService.GetUser(request.UserName);
            var auctionsWonByUser = new List<Auction>();
            if (user == null)
            {
                throw new ValidationException("User not found!");
            }

            foreach (var auction in auctions)
            {
                if(auction.Winner.Id == user.Id)
                {
                    auctionsWonByUser.Add(auction);
                }
                

            }

            await Task.CompletedTask;

            return auctionsWonByUser;
        }
    }
}
