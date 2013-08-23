using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using MetricsCorporation.Models;

namespace MetricsCorporation.Orchard.Api.Helpers
{
    public static class JigsawHelper
    {

        /// <summary>
        /// JigSaw token, stored in the web.config of the application
        /// </summary>
        private static string JIGSAW_TOKEN = ConfigurationManager.AppSettings["JigsawToken"];


        /// <summary>
        /// JigSaw userName stored in the web.config
        /// </summary>
        private static string JIGSAW_USER_NAME = ConfigurationManager.AppSettings["JigsawUserName"];


        /// <summary>
        /// JigSaw Password stored in the web.config
        /// </summary>
        private static string JIGSAW_PASSWORD = ConfigurationManager.AppSettings["JigsawPassword"];


        /// <summary>
        /// Url for getting companyId
        /// </summary>
        private static string JIGSAW_URL =
            "https://www.jigsaw.com/rest/searchCompany.xml?token={0}&name={1}";


        /// <summary>
        /// Url for getting all the contacts from the company
        /// </summary>
        private static string JIGSAW_CONTACTS_URL =
            "https://www.jigsaw.com/rest/searchContact.xml?token={0}&companyId={1}";



        /// <summary>
        /// Url for getting additional contact info
        /// </summary>
        private static string JIGSAW_PURCHASE_URL =
            "https://www.jigsaw.com/rest/contacts/{0}.xml?token={1}&username={2}&password={3}&purchaseFlag=true";



        /// <summary>
        /// By company name returning company id from jigsaw
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public static string GetCompanyId(string companyName)
        {
            string url = string.Format(JIGSAW_URL, JIGSAW_TOKEN, companyName.ToLowerInvariant().Replace("llc","").Replace("inc",""));
            string postData = "";

            var request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(stream, Encoding.UTF8);
                        string responseString = reader.ReadToEnd();

                        var doc = new XmlDocument();

                        doc.LoadXml(responseString);

                        foreach (var companiesList in doc.ChildNodes)
                        {
                            foreach (var child in (XmlNode)companiesList)
                            {
                                var item = (XmlElement)child;
                                if (item.Name == "companies")
                                {
                                    foreach (var data in item)
                                    {
                                        var dataItem = (XmlElement)data;

                                        foreach (XmlNode companyInfo in dataItem)
                                        {
                                            if (companyInfo.Name == "companyId")
                                            {
                                                postData = companyInfo.InnerText;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    var httpResponse = (HttpWebResponse)response;
                }
            }

            return postData;
        }


        /// <summary>
        /// By companyId returning all the contacts from the selected company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static IList<ContactModel> GetContacts(string companyId)
        {
            string url = string.Format(JIGSAW_CONTACTS_URL, JIGSAW_TOKEN, companyId);
            var contacts = new List<ContactModel>();

            var request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(stream, Encoding.UTF8);
                        string responseString = reader.ReadToEnd();

                        var doc = new XmlDocument();

                        doc.LoadXml(responseString);

                        foreach (XmlNode node in doc.FirstChild.ChildNodes)
                        {
                            if (node.Name == "contacts")
                            {
                                foreach (var item in node.ChildNodes)
                                {
                                    var contact = ContactModel(item);

                                    contacts.Add(contact);
                                }
                            }
                        }
                    }
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    var httpResponse = (HttpWebResponse)response;
                }
            }


            return contacts;
        }


        /// <summary>
        /// Returning contact with additional info, only for users who can purchase it
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public static ContactModel GetPurchasedContact(long contactId)
        {

            string url = string.Format(JIGSAW_PURCHASE_URL, contactId, JIGSAW_TOKEN, JIGSAW_USER_NAME, JIGSAW_PASSWORD);
            var contact = new ContactModel();

            var request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        var reader = new StreamReader(stream, Encoding.UTF8);
                        string responseString = reader.ReadToEnd();

                        var doc = new XmlDocument();

                        doc.LoadXml(responseString);

                        foreach (XmlNode node in doc.FirstChild.ChildNodes)
                        {
                            if (node.Name == "contacts")
                            {
                                foreach (var item in node.ChildNodes)
                                {
                                    contact = ContactModel(item);
                                }
                            }
                        }
                    }
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    var httpResponse = (HttpWebResponse)response;
                }
            }


            return contact;
        }


        /// <summary>
        /// Returning Contact with more info, should be purchased points
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ContactModel ContactModel(object item)
        {
            var contact = new ContactModel();
            foreach (XmlNode child in ((XmlNode)item).ChildNodes)
            {
                switch (child.Name)
                {
                    case "address":
                        contact.Address = child.InnerText;
                        break;
                    case "companyId":
                        contact.CompanyId = long.Parse(child.InnerText);
                        break;
                    case "contactId":
                        contact.ContactId = long.Parse(child.InnerText);
                        break;
                    case "title":
                        contact.Title = child.InnerText;
                        break;
                    case "companyName":
                        contact.CompanyName = child.InnerText;
                        break;
                    case "updatedDate":
                        contact.UpdatedDate = DateTime.Now; //DateTime.Parse(child.InnerText);
                        break;
                    case "graveyardStatus":
                        contact.GraveyardStatus = child.InnerText != "" && bool.Parse(child.InnerText);
                        break;
                    case "firstname":
                        contact.FirstName = child.InnerText;
                        break;
                    case "lastname":
                        contact.LastName = child.InnerText;
                        break;
                    case "city":
                        contact.City = child.InnerText;
                        break;
                    case "state":
                        contact.State = child.InnerText;
                        break;
                    case "country":
                        contact.Country = child.InnerText;
                        break;
                    case "zip":
                        contact.Zip = child.InnerText;
                        break;
                    case "contactURL":
                        contact.ContactUrl = child.InnerText;
                        break;
                    case "seoContactURL":
                        contact.SeoContactUrl = child.InnerText;
                        break;
                    case "areaCode":
                        contact.AreaCode = child.InnerText == "" ? 0 : int.Parse(child.InnerText);
                        break;
                    case "phone":
                        contact.Phone = child.InnerText;
                        break;
                    case "email":
                        contact.Email = child.InnerText;
                        break;
                    case "owned":
                        contact.Owned = child.InnerText != "" && bool.Parse(child.InnerText);
                        break;
                    case "ownedType":
                        contact.OwnedType = child.InnerText;
                        break;
                }
            }
            return contact;
        }
    }
}