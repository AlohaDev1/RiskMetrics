using System;
using System.Collections.Generic;

namespace MetricsCorporation.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Headline { get; set; }
        public string ProfileRequest { get; set; }
        public string LinkedInId { get; set; }

        public string Password { get; set; }
        public string FilePath { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string States { get; set; }
        public DateTime? ActivationDate { get; set; }
        public DateTime? RenewalDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string CompanyName { get; set; }

        public bool Admin { get; set; }
        public bool CanexportList { get; set; }

        public int MaxReportViewsPerMonth { get; set; }
        public int MaxExports { get; set; }

        public long MaxJigsawReportsViewsPerMonth { get; set; }
        public long MaxJigsawExports { get; set; }

        public int MaxReportViewsPerYear { get; set; }
        public int MaxJigsawReportsViewsPerYear { get; set; }
        
        //public int? ReportsViewByMonth { get; set; }
        //public int? ReportsJigwasByMonth { get; set; }
        public bool ReportsViewByMonth { get; set; }
        public bool ReportsJigwasByMonth { get; set; }
        

        public bool ShowCarrier { get; set; }
        public bool ShowStatusFld { get; set; }
        public bool InternalAccount { get; set; }
        public bool TestAccount { get; set; }

        /// <summary>
        /// /////////////////
        /// </summary>
        public int? LoginCount { get; set; }
        public int? TotalReportsViewed { get; set; }
        public int? TotalReportsExported { get; set; }

        public List<Role> Roles { get; set; }

        public UserModel()
        {
            Roles = new List<Role>();
        }
    }
}
