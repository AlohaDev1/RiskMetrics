using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Hammock;
using Hammock.Web;
using MetricsCorporation.Models;
using MetricsCorporation.Orchard.Web.Properties;

namespace MetricsCorporation.Orchard.Web.Helpers
{
    public class LinkedInConnector
    {
        private HttpContextBase Context { get; set; }
        private ControllerContext ControllerContext { get; set; }

        public LinkedInConnector(HttpContextBase context, ControllerContext controllerContext)
        {
            Context = context;
            ControllerContext = controllerContext;
        }

        public string RequestTokenAndAuthorize(string callbackPath)
        {
            var credentials = new Hammock.Authentication.OAuth.OAuthCredentials
            {

                CallbackUrl = string.Format(Settings.Default.LinkedInCallbackUrl, callbackPath),

                //ConsumerKey = "uir3aif0udas",
                //ConsumerKey = "gov1x4pvukq1",
                ConsumerSecret = "pVMiwaPDat3bKamo",

                //ConsumerSecret = "K0Jp8whsJYBRWSIA",
                //ConsumerSecret = "305o3XzOhOP6UW6G",
                ConsumerKey = "nihfrspjiiec",

                Type = Hammock.Authentication.OAuth.OAuthType.RequestToken
            };

            var client = new RestClient
            {
                Authority = "https://api.linkedin.com/uas/oauth",
                Credentials = credentials
            };

            var request = new RestRequest { Path = "requestToken?scope=r_basicprofile%20r_emailaddress" };
            //"scope", "r_emailaddress"
            //request.AddParameter("scope", "r_emailaddress");

            RestResponse response = client.Request(request);
            String[] strResponseAttributes = response.Content.Split('&');
            string token = strResponseAttributes[0].Substring(strResponseAttributes[0].LastIndexOf('=') + 1);
            string authToken = strResponseAttributes[1].Substring(strResponseAttributes[1].LastIndexOf('=') + 1);

            Context.Session["Token"] =  token;
            Context.Session["TokenSecret"] = authToken;
            return "https://www.linkedin.com/uas/oauth/authorize?oauth_token=" + token;
        }

        public void CallBack()
        {
            String verifier = Context.Request.QueryString["oauth_verifier"];
            Context.Session["Verifier"] = verifier;

            var credentials = new Hammock.Authentication.OAuth.OAuthCredentials
            {
                ConsumerSecret = "pVMiwaPDat3bKamo",

                //ConsumerSecret = "K0Jp8whsJYBRWSIA",
                //ConsumerSecret = "305o3XzOhOP6UW6G",
                ConsumerKey = "nihfrspjiiec",

                Token = Context.Session["Token"].ToString(),

                TokenSecret = Context.Session["TokenSecret"].ToString(),

                Verifier = verifier,

                Type = Hammock.Authentication.OAuth.OAuthType.AccessToken,

                ParameterHandling = Hammock.Authentication.OAuth.OAuthParameterHandling.HttpAuthorizationHeader,

                SignatureMethod = Hammock.Authentication.OAuth.OAuthSignatureMethod.HmacSha1,

                Version = "1.0"
            };

            var client = new RestClient { Authority = "https://api.linkedin.com/uas/oauth", Credentials = credentials, Method = WebMethod.Post };
            var request = new RestRequest { Path = "accessToken" };
            //request.AddParameter("scope", "r_emailaddress");
            RestResponse response = client.Request(request);
            String[] strResponseAttributes = response.Content.Split('&');
            string token = strResponseAttributes[0].Substring(strResponseAttributes[0].LastIndexOf('=') + 1);
            string authToken = strResponseAttributes[1].Substring(strResponseAttributes[1].LastIndexOf('=') + 1);

            Context.Session["AccessToken"] = token;
            Context.Session["AccessSecretToken"] = authToken;
        }

        public UserModel GetUserProfile()
        {
            //var request = new RestRequest { Path = "~" };
            var request = new RestRequest { };
            // var request = new RestRequest { Path = "requestToken?scope=r_basicprofile%20r_emailaddress" };

            var credentials = new Hammock.Authentication.OAuth.OAuthCredentials
            {
                Type = Hammock.Authentication.OAuth.OAuthType.AccessToken,

                SignatureMethod = Hammock.Authentication.OAuth.OAuthSignatureMethod.HmacSha1,

                ParameterHandling = Hammock.Authentication.OAuth.OAuthParameterHandling.HttpAuthorizationHeader,

                ConsumerSecret = "pVMiwaPDat3bKamo",

                //ConsumerSecret = "K0Jp8whsJYBRWSIA",
                //ConsumerSecret = "305o3XzOhOP6UW6G",
                ConsumerKey = "nihfrspjiiec",

                Token = Context.Session["AccessToken"].ToString(),

                TokenSecret = Context.Session["AccessSecretToken"].ToString(),

                Verifier = Context.Session["Verifier"].ToString(),

            };

            var client = new RestClient
            {
                Authority = "https://api.linkedin.com/v1/people/~:(id,first-name,last-name,headline,site-standard-profile-request,email-address)?format=json",
                Credentials = credentials,
                Method = WebMethod.Get
            };

            //request.AddParameter("scope", "r_basicprofile");
            var myInfo = client.Request(request);
            String content = myInfo.Content;
            var person = from c in XElement.Parse(content).Elements()
                         select c;

            var model = new UserModel();

            foreach (var element in person)
            {
                switch (element.Name.ToString())
                {
                    case "first-name":
                        model.FirstName = element.Value;
                        break;
                    case "last-name":
                        model.LastName = element.Value;
                        break;
                    case "headline":
                        model.Headline = element.Value;
                        break;
                    case "id":
                        model.LinkedInId = element.Value;
                        break;
                    case "site-standard-profile-request":
                        model.ProfileRequest = element.Value;
                        break;
                    case "email-address":
                        model.Email = element.Value;
                        break;

                }
            }

            return model;
        }
    }
}