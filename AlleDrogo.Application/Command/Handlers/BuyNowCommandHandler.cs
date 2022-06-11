using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Infrastructure.Identity;
using AlleDrogo.Internal.Contracts.Command;
using AlleDrogo.Internal.Contracts.Models;
using AlleDrogo.Persistance.Repository;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace AlleDrogo.Application.Command.Handlers
{
    public class BuyNowCommandHandler : IRequestHandler<BuyNowCommand, BuyNowResult>
    {
        private readonly IRepository<Auction> auctionRepository;
        private readonly IUserService userService;

        public BuyNowCommandHandler(IRepository<Auction> auctionRepository, IUserService userService)
        {
            this.auctionRepository = auctionRepository;
            this.userService = userService;
        }

        public async Task<BuyNowResult> Handle(BuyNowCommand request, CancellationToken cancellationToken)
        {
            var auction = auctionRepository.GetById(request.AuctionId);
            if (auction == null)
            {
                throw new ValidationException("Nie znaleziono aukcji. Prawdopodobnie została zakończona w czasie, kiedy licytowałeś.");
            }

            if (auction.IsSold)
            {
                throw new ValidationException("Aukcja została zakończona.");
            }

            var user = await userService.GetUser(request.Username);
            if (user == null)
            {
                throw new ValidationException("Nie znaleziono użytkownika.");
            }

            auction.BuyNow(user);
            auctionRepository.SaveChanges();

            return new BuyNowResult { Id = auction.Id };
        }
    }
}