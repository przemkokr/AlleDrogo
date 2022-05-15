using AlleDrogo.Application.Command.AuctionCommand;
using AlleDrogo.Domain.Entities.Auction;
using AlleDrogo.Domain.Entities.Bids;
using AlleDrogo.Domain.Entities.User;
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

        private readonly IRepository<User> userRepository;

        public BidAuctionCommandHandler(IRepository<Bid> bidRepository, IRepository<Auction> auctionRepository, IRepository<User> userRepository)
        {
            this.bidRepository = bidRepository;
            this.auctionRepository = auctionRepository;
            this.userRepository = userRepository;
        }

        Task<Unit> IRequestHandler<BidAuctionCommand, Unit>.Handle(BidAuctionCommand request, CancellationToken cancellationToken)
        {
            var auction = auctionRepository.GetById(request.AuctionId);
            if (auction == null)
            {
                throw new ValidationException("Auction not found!");
            }

            var user = userRepository.GetById(request.UserId);
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
                BuyNow(auction);
            }
            else
            {
                AddBid(auction, bid);
            }
            return Task.FromResult(Unit.Value);
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
