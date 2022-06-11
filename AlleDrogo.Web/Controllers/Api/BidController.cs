using AlleDrogo.Internal.Contracts.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AlleDrogo.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IMediator mediator;

        public BidController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("bid")]
        public async Task Bid([FromBody] BidAuctionCommand command)
        {
            await this.mediator.Send(command);
        }

        [HttpPost]
        [Route("buyNow")]
        public async Task<int> BuyNow([FromBody] BuyNowCommand command)
        {
            var response = await this.mediator.Send(command);

            return response.Id > 0 ? response.Id : 0;
        }
    }
}
