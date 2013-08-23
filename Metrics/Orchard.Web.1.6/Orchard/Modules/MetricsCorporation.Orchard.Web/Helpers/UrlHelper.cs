using MetricsCorporation.Models;

namespace MetricsCorporation.Orchard.Web.Helpers
{
    public static class UrlHelper
    {
        internal static string GetGoogleEarthUrl(GoogleEarthModel model)
        {
            return
                string.Format(
                    "http://maps.google.com/maps?q={0},+{1},+{2},+{3},+United+States,+{4}&maptype=hybrid&sensor=false&output=embed",
                    string.IsNullOrEmpty(model.Name) ? "" : model.Name.Replace(" ", "+"), 
                    string.IsNullOrEmpty(model.Address)? "" :  model.Address.Replace(" ", "+"), 
                    string.IsNullOrEmpty(model.City) ? "" : model.City.Replace(" ", "+"), model.State, model.Zip);
        }
    }
}