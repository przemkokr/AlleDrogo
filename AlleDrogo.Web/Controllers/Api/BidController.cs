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
        public async Task Bid([FromBody]BidAuctionCommand command)
        {
            await this.mediator.Send(command);
        }
    }
}
