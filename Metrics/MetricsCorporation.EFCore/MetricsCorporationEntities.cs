using System.Data.Objects;
using System.Data.Entity.Infrastructure;

namespace MetricsCorporation.EFCore
{
    public partial class state_schematicEntities
    {
        public ObjectContext ObjectContext
        {
            get { return ((IObjectContextAdapter)this).ObjectContext; }
        }

    }
}
