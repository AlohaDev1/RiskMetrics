/************************************************************
*
*	Entity class generated from MetricsCorporationModel.edmx
*
*************************************************************/
using System;
using System.Collections.Generic;

namespace MetricsCorporation.Entities
{
    
    public partial class filelist
    {
    
        public filelist()
        {
            this.searchlogs = new HashSet<searchlog>();
            this.number_of_logins = new HashSet<number_of_logins>();
            this.jigsaw_logins = new HashSet<jigsaw_logins>();
            this.user_states = new HashSet<user_states>();
        }
    
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
        public virtual ICollection<searchlog> searchlogs { get; set; }
        public virtual ICollection<number_of_logins> number_of_logins { get; set; }
        public virtual ICollection<jigsaw_logins> jigsaw_logins { get; set; }
        public virtual ICollection<user_states> user_states { get; set; }
    
    }
}
