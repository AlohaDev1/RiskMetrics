namespace MetricsCorporation.Models
{
    public class SearchLogModel
    {
        public int Qui { get; set; }
        public int Id { get; set; }
        public string SearchName { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string SicCode { get; set; }
        public string EffectiveMonth { get; set; }
        public bool PhoneEmp { get; set; }
        public string EmpSizeRange { get; set; }
        public string CountyName { get; set; }
        public string ClassCode { get; set; }
    }
}
