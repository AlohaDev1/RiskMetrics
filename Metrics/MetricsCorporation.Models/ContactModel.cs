using System;

namespace MetricsCorporation.Models
{
    public class ContactModel
    {
        public long CompanyId { get; set; }

        public long ContactId { get; set; }

        public string Title { get; set; }

        public string CompanyName { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool GraveyardStatus { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Zip { get; set; }

        public string ContactUrl { get; set; }

        public string SeoContactUrl { get; set; }

        public int AreaCode { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool Owned { get; set; }

        public string OwnedType { get; set; }
    }
}
