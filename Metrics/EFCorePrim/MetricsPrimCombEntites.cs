using System.Data.Objects;
using System.Data.Entity.Infrastructure;

namespace MetricsCorporation.EFCorePrim
{
    public partial class MetricsCorporationPrimComb
    {
        public ObjectContext ObjectContext
        {
            get { return ((IObjectContextAdapter)this).ObjectContext; }
        }

    }
}
