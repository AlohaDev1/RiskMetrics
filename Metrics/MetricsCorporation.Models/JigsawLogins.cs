using System;

namespace MetricsCorporation.Models
{
    public class JigsawLogins
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public bool Status { get; set; }
    }
}
