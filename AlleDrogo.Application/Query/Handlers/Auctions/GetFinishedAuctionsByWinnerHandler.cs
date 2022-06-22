using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Infrastructure.Identity;
using AlleDrogo.Internal.Contracts.Query.Auctions;
using AlleDrogo.Persistance.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlleDrogo.Application.Query.Handlers.Auctions
{
    public class GetFinishedAuctionsByWinnerHandler : IRequestHandler<GetFinishedAuctionsByWinner, IEnumerable<Auction>>
    {
        private readonly IRepository<Auction> _auctionRepository;
        private readonly IUserService _userService;

        public GetFinishedAuctionsByWinnerHandler(IRepository<Auction> auctionRepository, IUserService userService)
        {
            _auctionRepository = auctionRepository;
            _userService = userService;
        }
        public async Task<IEnumerable<Auction>> Handle(GetFinishedAuctionsByWinner request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(request.UserName);

            if (user == null)
            {
                throw new ValidationException("Błąd. Nie znaleziono użytkownika.");
            }

            var auctionsWonByUser = _auctionRepository
                .Find(a => a.IsSold && a.Winner != null && a.Winner.Id == user.Id)
                .ToList();            

            return auctionsWonByUser;
        }
    }
}
