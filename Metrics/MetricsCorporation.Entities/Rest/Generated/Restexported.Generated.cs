/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities.Rest
{
    
    public partial class Restexported
    {
    
        public int Id { get; set; }
        public Nullable<System.DateTime> ExportedOn { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> RecordsExportedCount { get; set; }
        public string FileName { get; set; }
    
    }
}
