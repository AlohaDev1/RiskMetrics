/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities
{
    
    public partial class searchlog
    {
    
        public int qui { get; set; }
        public int id { get; set; }
        public string searchname { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string SICCode { get; set; }
        public string EffectiveMonth { get; set; }
        public bool PhoneEmp { get; set; }
        public string EmpSizeRange { get; set; }
        public string CountyName { get; set; }
        public bool Active { get; set; }
        public string searchlogcol { get; set; }
        public virtual filelist filelist { get; set; }
    
    }
}
