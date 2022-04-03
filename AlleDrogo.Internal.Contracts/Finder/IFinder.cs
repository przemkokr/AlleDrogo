using AlleDrogo.Internal.Contracts.ReadModels.Base;
using System.Collections.Generic;

namespace AlleDrogo.Internal.Contracts.Finder
{
    public interface IFinder<T> where T : ReadModelBase
    {
        IEnumerable<T> Query();
    }
}
