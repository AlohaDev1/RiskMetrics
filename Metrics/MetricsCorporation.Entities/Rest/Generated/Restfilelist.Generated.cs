/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities.Rest
{
    
    public partial class Restfilelist
    {
    
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string filepath { get; set; }
        public Nullable<System.DateTime> lastloginDate { get; set; }
        public string states { get; set; }
        public Nullable<System.DateTime> activationdate { get; set; }
        public Nullable<System.DateTime> renewaldate { get; set; }
        public Nullable<System.DateTime> expirationdate { get; set; }
        public string CompanyName { get; set; }
        public string name { get; set; }
        public bool admin { get; set; }
        public bool canexportlist { get; set; }
        public int maxreportviewspermonth { get; set; }
        public long maxexports { get; set; }
        public long maxjigsawreportsviewspermonth { get; set; }
        public long maxjigsawexports { get; set; }
    
    }
}
