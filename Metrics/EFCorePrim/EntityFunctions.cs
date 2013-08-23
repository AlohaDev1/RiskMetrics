using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace MetricsCorporation.EFCorePrim
{
    //http://blogs.msdn.com/b/efdesign/archive/2008/10/08/edm-and-store-functions-exposed-in-linq.aspx
    //http://jendaperl.blogspot.it/2011/02/like-in-linq-to-entities.html

    // WARNING: the reference to the edmx namespace in ([EdmFunction("<edmx namespace>", "String_Like")])
    // it's case sensitive, so the namespace "miSafeModel" IS NOT LIKE the namespace "MiSafeModel"
    // this file throw an exception when it doesn't found the String_Like function in the specified edmx.

    public static class EntityFunctions
    {
        [EdmFunction("MetricsPrimCombEntites", "String_Like")]
        public static Boolean Like(this String searchingIn, String lookingFor)
        {
             throw new NotSupportedException("Direct calls not supported");  
        }
    }
}
