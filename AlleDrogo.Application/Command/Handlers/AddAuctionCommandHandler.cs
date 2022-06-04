﻿using AlleDrogo.Domain.Entities.Auctions;
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
    internal class AddAuctionCommandHandler : IRequestHandler<AddAuctionCommand, AddAuctionResult>
    {
        private readonly IRepository<Auction> auctionRepository;
        private readonly IRepository<AuctionItem> auctionItemRepository;
        private readonly IUserService userService;

        public AddAuctionCommandHandler(IRepository<Auction> auctionRepository, IRepository<AuctionItem> auctionItemRepository, IUserService userService)
        {
            this.auctionRepository = auctionRepository;
            this.auctionItemRepository = auctionItemRepository;
            this.userService = userService;
        }

        public async Task<AddAuctionResult> Handle(AddAuctionCommand request, CancellationToken cancellationToken)
        {
            var auctionItem = await AddAuctionItem(request.Item);
            var auction = await AddAuction(request, auctionItem);
            return new AddAuctionResult { Id = auction.Id };
        }

        private async Task<AuctionItem> AddAuctionItem(AuctionItemModel item)
        {
            var auctionItem = new AuctionItem(
                item.Name,
                await ResolveCategory(item.Category),
                item.Description,
                true
                );

            auctionItemRepository.Add(auctionItem);
            auctionItemRepository.SaveChanges();
            return auctionItem;
        }

        private async Task<Category> ResolveCategory(CategoryEnum category)
        {
            await Task.CompletedTask;

            return category switch
            {
                CategoryEnum.CARS => Category.CARS,
                CategoryEnum.FASHION => Category.FASHION,
                CategoryEnum.ELECTRONICS => Category.ELECTRONICS,
                CategoryEnum.PLANTS => Category.PLANTS,
                CategoryEnum.SERVICES => Category.SERVICES,
                CategoryEnum.GAMES => Category.GAMES,
                CategoryEnum.DRUGS => Category.DRUGS,
                CategoryEnum.FURNITURE => Category.FURNITURE,
                CategoryEnum.CULTURE => Category.CULTURE,
                CategoryEnum.BEAUTY => Category.BEAUTY,
                CategoryEnum.BRIBES_FOR_GOOD_GRADES_FOR_THE_DEVELOPMENT_TEAM => Category.BRIBES_FOR_GOOD_GRADES_FOR_THE_DEVELOPMENT_TEAM,
                _ => throw new ValidationException("Nieobsługiwana kategoria!")
            };
        }

        private async Task<Auction> AddAuction(AddAuctionCommand request, AuctionItem auctionItem)
        {
            var user = await this.userService.GetUser(request.Username);
            if (user == null)
            {
                throw new ValidationException("Nie znaleziono użytkownika!");
            }

            var auction = new Auction(
                request.Title,
                auctionItem,
                user,
                DateTime.Now,
                request.EndDate,
                request.Description,
                Decimal.One,
                request.IsBuyNow,
                false
            );

            auctionRepository.Add(auction);
            auctionRepository.SaveChanges();
            return auction;
        }
    }
}
