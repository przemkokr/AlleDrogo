using AlleDrogo.Internal.Contracts.ReadModels.Base;

namespace AlleDrogo.Internal.Contracts.ReadModels
{
    public class SampleReadModelClass : ReadModelBase
    {
        // this class and properties would be mapped from domain entities via AutoMapper
        public string Test { get; set; }
    }
}
