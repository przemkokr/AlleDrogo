using AlleDrogo.Domain.Entities.Auction;
using AlleDrogo.Internal.Contracts.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    }
}
