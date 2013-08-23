/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities
{
    
    public partial class number_of_logins
    {
    
        public int id { get; set; }
        public int user_id { get; set; }
        public System.DateTime login_date { get; set; }
        public int count { get; set; }
        public Nullable<long> number_of_logins1 { get; set; }
        public virtual filelist filelist { get; set; }
    
    }
}
