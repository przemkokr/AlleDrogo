using AlleDrogo.Domain.Entities.Auctions;
using AlleDrogo.Internal.Contracts.Query.Auctions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlleDrogo.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuctionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IEnumerable<Auction>> GetAuctions()
        {
            var auctions = await mediator.Send(new GetAuctionsQuery());

            return auctions;
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<Auction> GetAuction(int id)
        {
            var auctions = await mediator.Send(new GetAuctionsQuery());

            return auctions.FirstOrDefault(a => a.Id == id);
        }
    }
}
