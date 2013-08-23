/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities
{
    
    public partial class exported_company
    {
    
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public Nullable<int> ExportedId { get; set; }
        public virtual exported exported { get; set; }
    
    }
}
