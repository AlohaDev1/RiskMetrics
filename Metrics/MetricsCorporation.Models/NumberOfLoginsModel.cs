using System;

namespace MetricsCorporation.Models
{
    public class NumberOfLoginsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public int Count { get; set; }
    }
}
