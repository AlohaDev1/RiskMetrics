using System.IO;
using System.Xml;
using MetricsCorporation.Models;

namespace MetricsCorporation.Helpers
{
    public static class XmlHelper
    {
        public static byte[] GetCompanyModelFile(CompanyModel model)
        {
            var doc = GetReportCrmXml(model);

            var ms = new MemoryStream();
            doc.Save(ms);

            return ms.ToArray();
        }

        public static byte[] GetClientModelFile(ContactModel model)
        {
            var doc = GetClientReportCrmXml(model);

            var ms = new MemoryStream();
            doc.Save(ms);

            return ms.ToArray();
        }

        private static XmlDocument GetReportCrmXml(CompanyModel model)
        {
            var doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            XmlElement element = doc.CreateElement("CompanyName");

            element.InnerText = model.CompanyName;
            root.AppendChild(element);

            element = doc.CreateElement("State");

            element.InnerText = model.State;
            root.AppendChild(element);

            element = doc.CreateElement("City");

            element.InnerText = model.City;
            root.AppendChild(element);

            element = doc.CreateElement("Address");

            element.InnerText = model.Address;
            root.AppendChild(element);

            element = doc.CreateElement("Phone");

            element.InnerText = model.Phone;
            root.AppendChild(element);

            element = doc.CreateElement("PolicyRenewalDate");

            element.InnerText = model.PolicyRenewalDate;
            root.AppendChild(element);

            element = doc.CreateElement("CarrierOfRecord");

            element.InnerText = model.CarrierOfRecord;
            root.AppendChild(element);

            element = doc.CreateElement("CarrierGroupName");

            element.InnerText = model.CarrierGroupName;
            root.AppendChild(element);

            element = doc.CreateElement("ContactName");

            element.InnerText = model.ContactName;
            root.AppendChild(element);

            element = doc.CreateElement("SicCode");

            element.InnerText = model.SicCode;
            root.AppendChild(element);

            element = doc.CreateElement("ClassCode");

            element.InnerText = model.ClassCode;
            root.AppendChild(element);

            element = doc.CreateElement("Status");

            element.InnerText = model.Status;
            root.AppendChild(element);


            doc.AppendChild(root);
            return doc;
        }

        private static XmlDocument GetClientReportCrmXml(ContactModel model)
        {
            var doc = new XmlDocument();
            XmlElement root = doc.CreateElement("root");
            XmlElement element = doc.CreateElement("FirstName");

            element.InnerText = model.FirstName;
            root.AppendChild(element);

            element = doc.CreateElement("LastName");

            element.InnerText = model.LastName;
            root.AppendChild(element);

            element = doc.CreateElement("Title");

            element.InnerText = model.Title;
            root.AppendChild(element);

            element = doc.CreateElement("Address");

            element.InnerText = model.Address;
            root.AppendChild(element);

            element = doc.CreateElement("AreaCode");

            element.InnerText = model.AreaCode.ToString();
            root.AppendChild(element);

            element = doc.CreateElement("City");

            element.InnerText = model.City;
            root.AppendChild(element);

            element = doc.CreateElement("State");

            element.InnerText = model.State;
            root.AppendChild(element);

            element = doc.CreateElement("Country");

            element.InnerText = model.Country;
            root.AppendChild(element);

            element = doc.CreateElement("Zip");

            element.InnerText = model.Zip;
            root.AppendChild(element);

            element = doc.CreateElement("CompanyName");

            element.InnerText = model.CompanyName;
            root.AppendChild(element);

            element = doc.CreateElement("Email");

            element.InnerText = model.Email;
            root.AppendChild(element);

            element = doc.CreateElement("Phone");

            element.InnerText = model.Phone;
            root.AppendChild(element);

            element = doc.CreateElement("GraveyardStatus");

            element.InnerText = model.GraveyardStatus.ToString();
            root.AppendChild(element);

            doc.AppendChild(root);
            return doc;
        }

    }
}