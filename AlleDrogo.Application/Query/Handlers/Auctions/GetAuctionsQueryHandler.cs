using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Internal.Contracts.Query.Auctions;
using AlleDrogo.Persistance.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlleDrogo.Application.Query.Handlers.Auctions
{
    public class GetAuctionsQueryHandler : IRequestHandler<GetAuctionsQuery, IEnumerable<Auction>>
    {
        private readonly IRepository<Auction> auctionRepository;

        public GetAuctionsQueryHandler(
            IRepository<Auction> auctionRepository)
        {
            this.auctionRepository = auctionRepository;
        }

        public async Task<IEnumerable<Auction>> Handle(GetAuctionsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var auctions = auctionRepository.GetAll();

            var result = auctions.Where(a => a.EndDate > DateTime.Now).ToList();

            return result;
        }
    }
}
