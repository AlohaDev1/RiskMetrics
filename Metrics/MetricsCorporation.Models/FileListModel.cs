using System;
using System.Collections.Generic;

namespace MetricsCorporation.Models
{
    public class FileListModel
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FilePath { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string States { get; set; }
        public DateTime? ActivationDate { get; set; }
        public DateTime? RenewalDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Admin { get; set; }
        public bool CanexportList { get; set; }
        public int MaxReportViewsPerMonth { get; set; }
        public int MaxExports { get; set; }

        public long MaxJigsawReportsViewsPerMonth { get; set; }
        public long MaxJigsawExports { get; set; }

        public bool ShowCarrier { get; set; }
        public bool ShowStatusFld { get; set; }

        public IEnumerable<string> Roles;

        public FileListModel()
        {
            Roles = new[] { "Master" };
        }
    }
}
