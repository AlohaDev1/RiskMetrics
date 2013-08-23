using System;

namespace MetricsCorporation.Models
{
    public class UsageInfoModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int ReportId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ZipPlus4 { get; set; }
        //changed to string from int for countyName
        public string ClassCode { get; set; }
        public string CountyName { get; set; }
        public string SicCode { get; set; }
        public string Status { get; set; }
        public string EffectiveDate { get; set; }
        public string CarrierNum { get; set; }
        public string PhoneEmp { get; set; }
        public string ContactName { get; set; }
        public string EmpsizeRange { get; set; }
        public string SalesVolRange { get; set; }
        public string CarrierТame { get; set; }
        public string СountyТame { get; set; }
        public string NaicCarrierNumber { get; set; }
        public string NaicGroupName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
