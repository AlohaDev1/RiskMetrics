/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities
{
    
    public partial class exported
    {
    
        public exported()
        {
            this.exported_company = new HashSet<exported_company>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> ExportedOn { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> RecordsExportedCount { get; set; }
        public string FileName { get; set; }
        public virtual ICollection<exported_company> exported_company { get; set; }
    
    }
}
