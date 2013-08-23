/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities
{
    
    public partial class usageinfo
    {
    
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public int reportid { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string zipplus4 { get; set; }
        public int classcode { get; set; }
        public int siccode { get; set; }
        public string status { get; set; }
        public string effectivedate { get; set; }
        public string carriernum { get; set; }
        public string phoneemp { get; set; }
        public string contactname { get; set; }
        public string empsizerange { get; set; }
        public string salesvolrange { get; set; }
        public string carriername { get; set; }
        public string countyname { get; set; }
        public string NAICCarrierNumber { get; set; }
        public string NAICGroupName { get; set; }
        public System.DateTime createdAt { get; set; }
    
    }
}
