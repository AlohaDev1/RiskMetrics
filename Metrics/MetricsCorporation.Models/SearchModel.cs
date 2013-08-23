using System.Collections.Generic;
using System.ComponentModel;

namespace MetricsCorporation.Models
{
    public class SearchModel
    {
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        //[DisplayName("Carrier Name")]
        //public string CarrierName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string[] CountyName { get; set; }

        public bool HasPhoneNumber { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Sic Code")]
        public string SicCode { get; set; }

        public string[] SicCodes { get; set; }

        public string[] ClassCodes { get; set; }

        [DisplayName("Renewal Month")]
        public string[] RenewalMonths { get; set; }

        [DisplayName("Employee Size")]
        public string[] EmployeeSize { get; set; }

        [DisplayName("Search Name")]
        public string SearchName { get; set; }

        public string[] States { get; set; }

        public decimal?[] CarrierNumbers { get; set; }

        public string[] CarrierGroups { get; set; }
        
    }

    public class SearchResponseModel
    {
        public IEnumerable<CompanyGrid> Companies { get; set; }
        public int Total { get; set; }
        public int Showed { get; set; }
        public bool ShowCarrier { get; set; }
        public bool ShowStatusFld { get; set; }
        public int UserId { get; set; }
    }

    //public class SearchResponseModel
    //{
    //    public IEnumerable<CompanyModel> Companies { get; set; }
    //    public int Total { get; set; }
    //    public int Showed { get; set; }
    //    public bool ShowCarrier { get; set; }
    //    public bool ShowStatusFld { get; set; }
    //    public int UserId { get; set; }
    //}
}
