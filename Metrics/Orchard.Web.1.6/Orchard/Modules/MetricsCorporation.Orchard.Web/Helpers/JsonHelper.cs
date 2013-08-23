using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MetricsCorporation.Orchard.Web.Helpers
{
    public static class JsonHelper
    {
        public static string Serialize(object data)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeLocal, DateTimeFormat = "yyyy-MM-ddTHH:mm:ss" });
            settings.Converters.Add(new StringEnumConverter());
            settings.TypeNameHandling = TypeNameHandling.None;


            return JsonConvert.SerializeObject(data, Formatting.Indented, settings);
        }
    }
}