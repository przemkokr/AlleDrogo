using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Domain.Entities.Bids;
using AlleDrogo.Infrastructure.Identity;
using AlleDrogo.Internal.Contracts.Command;
using AlleDrogo.Persistance.Repository;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace AlleDrogo.Application.Command.Handlers
{
    public class BidAuctionCommandHandler : IRequestHandler<BidAuctionCommand>
    {
        private readonly IRepository<Auction> auctionRepository;
        private readonly IUserService userService;

        public BidAuctionCommandHandler(IRepository<Auction> auctionRepository, IUserService userService)
        {
            this.auctionRepository = auctionRepository;
            this.userService = userService;
        }

        public async Task<Unit> Handle(BidAuctionCommand request, CancellationToken cancellationToken)
        {
            var auction = auctionRepository.GetById(request.AuctionId);
            if (auction == null)
            {
                throw new ValidationException("Nie znaleziono aukcji. Prawdopodobnie została zakończona w czasie, kiedy licytowałeś.");
            }

            var user = await this.userService.GetUser(request.Username);
            if (user == null)
            {
                throw new ValidationException("Nie znaleziono użytkownika.");
            }

            var bid = new Bid(
                auction,
                user,
                request.BidAmount,
                request.BiddingTime
            );

            if (bid.BidAmount <= auction.CurrentValue)
            {
                throw new ValidationException("Oferta, którą składasz, musi być wyższa niż aktualna wartość przedmiotu w aukcji.");
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
        }
    }
}
