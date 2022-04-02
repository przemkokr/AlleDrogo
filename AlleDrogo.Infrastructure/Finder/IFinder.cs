using AlleDrogo.Internal.Contracts.ReadModels.Base;
using System.Collections.Generic;

namespace AlleDrogo.Infrastructure.Finder
{
    public interface IFinder<T> where T : ReadModelBase
    {
        IEnumerable<T> Query();
    }
}
