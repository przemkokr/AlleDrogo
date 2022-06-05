using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Infrastructure.Identity;
using AlleDrogo.Internal.Contracts.Command;
using AlleDrogo.Internal.Contracts.Models;
using AlleDrogo.Persistance.Repository;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace AlleDrogo.Application.Command.Handlers
{
    public class AddAuctionCommandHandler : IRequestHandler<AddAuctionCommand, AddAuctionResult>
    {
        private readonly IRepository<Auction> auctionRepository;
        private readonly IUserService userService;

        public AddAuctionCommandHandler(IRepository<Auction> auctionRepository, IUserService userService)
        {
            this.auctionRepository = auctionRepository;
            this.userService = userService;
        }

        public async Task<AddAuctionResult> Handle(AddAuctionCommand request, CancellationToken cancellationToken)
        {
            var auction = await AddAuction(request);
            return new AddAuctionResult { Id = auction.Id };
        }

        private async Task<Auction> AddAuction(AddAuctionCommand request)
        {
            var user = await this.userService.GetUser(request.Username);
            if (user == null)
            {
                throw new ValidationException("Nie znaleziono użytkownika!");
            }

            var category = Enum.Parse<Category>(request.Item.Category.ToString());
            var item = new AuctionItem(request.Item.Name, category, request.Item.Description, request.Item.IsNew);

            var auction = new Auction(
                request.Title,
                item,
                user,
                DateTime.Now,
                request.EndDate,
                request.Description,
                request.InitialValue,
                request.IsBuyNow,
                false
            );

            if (auction.IsBuyNow)
            {
                auction.SetBuyNowValue(request.BuyNowValue.Value);
            }

            auctionRepository.Add(auction);
            auctionRepository.SaveChanges();
            return auction;
        }
    }
}
