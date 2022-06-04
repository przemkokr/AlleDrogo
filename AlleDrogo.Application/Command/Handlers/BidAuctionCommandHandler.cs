using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Domain.Entities.Bids;
using AlleDrogo.Infrastructure.Identity;
using AlleDrogo.Internal.Contracts.Command;
using AlleDrogo.Persistance.Repository;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace AlleDrogo.Application.Command.Handlers.AuctionCommandHandler
{
    internal class BidAuctionCommandHandler : IRequestHandler<BidAuctionCommand>
    {
        private readonly IRepository<Bid> bidRepository;
        private readonly IRepository<Auction> auctionRepository;
        private readonly IUserService userService;

        public BidAuctionCommandHandler(IRepository<Bid> bidRepository, IRepository<Auction> auctionRepository, IUserService userService)
        {
            this.bidRepository = bidRepository;
            this.auctionRepository = auctionRepository;
            this.userService = userService;
        }

        public async Task<Unit> Handle(BidAuctionCommand request, CancellationToken cancellationToken)
        {
            var auction = auctionRepository.GetById(request.AuctionId);
            if (auction == null)
            {
                throw new ValidationException("Auction not found!");
            }

            var user = await this.userService.GetUser(request.Username);
            if (user == null)
            {
                throw new ValidationException("User not found!");
            }

            var bid = new Bid(
                auction,
                user,
                request.BidAmount,
                request.BiddingTime
            );

            if (bid.BidAmount <= auction.CurrentValue)
            {
                throw new ValidationException("Bid value must be higher than current value!");
            }
            else if (bid.BidAmount >= auction.BuyNowValue)
            {
                auction.SetWinner(user);
                BuyNow(auction);
            }
            else
            {
                auction.SetWinner(user);
                AddBid(auction, bid);
            }

            return Unit.Value;
        }

        private void BuyNow(Auction auction)
        {
            auction.SetSold();

            auctionRepository.SaveChanges();
        }

        private void AddBid(Auction auction, Bid bid)
        {
            auction.AddBid(bid);
            auctionRepository.SaveChanges();

            bidRepository.Add(bid);
            bidRepository.SaveChanges();
        }
    }
}
