/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities
{
    
    public partial class loginfo
    {
    
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public System.DateTime lastloginDate { get; set; }
        public string CompanyName { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> lastlogoutDate { get; set; }
        public string eventtype { get; set; }
        public int ReportCount { get; set; }
    
    }
}
