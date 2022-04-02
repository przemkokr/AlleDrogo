using AlleDrogo.Internal.Contracts.ReadModels.Base;
using System.Collections.Generic;

namespace AlleDrogo.Infrastructure.Finder
{
    public class Finder<T> : IFinder<T> where T : ReadModelBase
    {
        public IEnumerable<T> Query()
        {
            throw new System.NotImplementedException();
        }
    }
}
