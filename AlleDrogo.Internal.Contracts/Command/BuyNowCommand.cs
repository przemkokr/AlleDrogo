using AlleDrogo.Internal.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlleDrogo.Internal.Contracts.Command
{
    public class BuyNowCommand : IRequest<BuyNowResult>
    {
        public int AuctionId { get; set; }

        public string Username { get; set; }
    }
}
