/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities
{
    
    public partial class user_states
    {
    
        public int id { get; set; }
        public int userId { get; set; }
        public string state_name { get; set; }
        public virtual filelist filelist { get; set; }
    
    }
}
