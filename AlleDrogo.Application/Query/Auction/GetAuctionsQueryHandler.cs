using AlleDrogo.Domain.Entities.Auction;
using AlleDrogo.Internal.Contracts.Query;
using AlleDrogo.Persistance.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlleDrogo.Application.Query.Auctions
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

            var auctions = this.auctionRepository.GetAll();

            var result = auctions.Where(a => a.EndDate > DateTime.Now).ToList();

            return result;
        }
    }
}
