using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetricsCorporation.Models
{
    public class ExportedModel
    {
        public int Id { get; set; }
        public DateTime ExportedOn { get; set; }
        public int RecordsExportedCount { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public List<long> CompanyIds { get; set; }

        public ExportedModel()
        {
            CompanyIds = new List<long>();
        }
    }

}
