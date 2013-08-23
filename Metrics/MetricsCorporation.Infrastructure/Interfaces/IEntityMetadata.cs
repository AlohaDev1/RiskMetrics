using System.Collections.Generic;
namespace MetricsCorporation.Infrastructure.Interfaces
{
    public interface IEntityMetadata
    {
        List<string> MandatoryFields { get; }
        List<string> PrimaryKey { get; }
        Dictionary<string, string> Fields { get; }
    }
}
