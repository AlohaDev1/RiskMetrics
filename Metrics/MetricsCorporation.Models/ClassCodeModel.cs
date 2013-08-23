using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetricsCorporation.Models
{
   public class ClassCodeModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

   public class ClassCodeAjaxReturn
   {
       public string Id { get; set; }
       public string Code { get; set; }
       public string Description { get; set; }
       public string[] Attribute { get; set; }
       public List<ClassCodeAjaxReturn> Childrens { get; set; } 
   }
}
