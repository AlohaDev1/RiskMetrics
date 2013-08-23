using System.Collections.Generic;

namespace MetricsCorporation.Models
{
    public class StateCountyModel
    {
        public string StateDescription { get; set; }

        public string StatePrefix { get; set; }

        public string CountyDescription { get; set; }

        public int CountyId { get; set; }
    }

    public class GeographyModel
    {
        public string StateDescription { get; set; }

        public string StatePrefix { get; set; }

        public IEnumerable<CountyModel> Countys { get; set; }
    }
}
