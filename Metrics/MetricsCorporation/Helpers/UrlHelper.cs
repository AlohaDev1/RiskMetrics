using System.Text;
using MetricsCorporation.Models;

namespace MetricsCorporation.Helpers
{
    public static class UrlHelper
    {
        internal static string GetGoogleEarthUrl(GoogleEarthModel model)
        {
            var builder = new StringBuilder("https://maps.google.com/maps?q=");

            if (!string.IsNullOrEmpty(model.Name))
            {
                builder.Append(model.Name.Replace(" ", "+"));
            }

            if (!string.IsNullOrEmpty(model.Address))
            {
                builder.Append(",+");
                builder.Append(model.Address.Replace(" ", "+"));
            }

            if (!string.IsNullOrEmpty(model.City))
            {
                builder.Append(",+");
                builder.Append(model.City.Replace(" ", "+"));
            }

            if (!string.IsNullOrEmpty(model.State))
            {
                builder.Append(",+");
                builder.Append(model.State.Replace(" ", "+"));
            }

            builder.Append(",+United+States");
            if (!string.IsNullOrEmpty(model.Zip))
            {
                builder.Append(",+");
                builder.Append(model.Zip.Replace(" ", "+"));
            }

            builder.Append("&maptype=hybrid&sensor=false&output=embed");


            return builder.ToString();
        }
    }
}