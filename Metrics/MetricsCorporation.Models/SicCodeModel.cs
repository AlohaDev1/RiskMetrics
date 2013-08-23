using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetricsCorporation.Models
{
    public class SicCodeModel
    {
        public int Id { get; set; }

        public string Division_Letter { get; set; }

        public string Division_Name { get; set; }

        public string SIC_2_Digit_Code { get; set; }

        public string SIC_2_Digit_Code_Name { get; set; }

        public string SIC_3_Digit_Code { get; set; }

        public string SIC_3_Digit_Code_Name { get; set; }

        public string SIC_4_Digit_Code { get; set; }

        public string SIC_4_Digit_Code_Name { get; set; }
    }
}
