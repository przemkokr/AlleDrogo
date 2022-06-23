using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlleDrogo.Internal.Contracts.Query.Auctions
{
    public class GetByUserQuery
    {
        public QueryType QueryType { get; set; }

        public string Username { get; set; }
    }
}
