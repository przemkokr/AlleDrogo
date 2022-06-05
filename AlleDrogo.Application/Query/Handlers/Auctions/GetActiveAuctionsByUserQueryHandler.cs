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
    public class GetActiveAuctionsByUserQueryHandler : IRequestHandler<GetActiveAuctionsByUserQuery, IEnumerable<Auction>>
    {
        private readonly IRepository<Auction> _auctionRepository;
        private readonly IUserService userService;

        public GetActiveAuctionsByUserQueryHandler(IRepository<Auction> auctionRepository, IUserService userService)
        {
            _auctionRepository = auctionRepository;
            this.userService = userService;
        }


        public async Task<IEnumerable<Auction>> Handle(GetActiveAuctionsByUserQuery request, CancellationToken cancellationToken)
        {
            var auctions = _auctionRepository.GetAll().Where(a => a.EndDate > DateTime.Now);
            var usersAuctions = new List<Auction>();
            var user = await userService.GetUser(request.UserName);
            if (user == null)
            {
                throw new ValidationException("User not found!");
            }

            foreach (var auction in auctions)
            {
                var bids = auction.Bids;
                foreach (var bid in bids)
                {
                    if (bid.User.Id == user.Id)
                    {
                        usersAuctions.Add(auction);
                    }
                    break;
                }
            }
            await Task.CompletedTask;
            return usersAuctions;
        }
    }
}
