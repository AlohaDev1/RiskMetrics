using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Hammock;
using Hammock.Web;
using MetricsCorporation.Models;

namespace MetricsCorporation.Helpers
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

        public string RequestTokenAndAuthorize()
        {
            var credentials = new Hammock.Authentication.OAuth.OAuthCredentials
            {
                CallbackUrl = "http://localhost:63692/Account/Confirm",

                ConsumerKey = "uir3aif0udas",

                ConsumerSecret = "K0Jp8whsJYBRWSIA",

                Type = Hammock.Authentication.OAuth.OAuthType.RequestToken
            };

            var client = new RestClient
            {
                Authority = "https://api.linkedin.com/uas/oauth",
                Credentials = credentials
            };

            var request = new RestRequest { Path = "requestToken" };
            RestResponse response = client.Request(request);
            String[] strResponseAttributes = response.Content.Split('&');
            string token = strResponseAttributes[0].Substring(strResponseAttributes[0].LastIndexOf('=') + 1);
            string authToken = strResponseAttributes[1].Substring(strResponseAttributes[1].LastIndexOf('=') + 1);

            Context.Session["Token"] = token;
            Context.Session["TokenSecret"] = authToken;
            return "https://www.linkedin.com/uas/oauth/authorize?oauth_token=" + token;
        }

        public void CallBack()
        {
            String verifier = Context.Request.QueryString["oauth_verifier"];
            Context.Session["Verifier"] = verifier;

            var credentials = new Hammock.Authentication.OAuth.OAuthCredentials
            {
                ConsumerKey = "uir3aif0udas",

                ConsumerSecret = "K0Jp8whsJYBRWSIA",

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
            RestResponse response = client.Request(request);
            String[] strResponseAttributes = response.Content.Split('&');
            string token = strResponseAttributes[0].Substring(strResponseAttributes[0].LastIndexOf('=') + 1);
            string authToken = strResponseAttributes[1].Substring(strResponseAttributes[1].LastIndexOf('=') + 1);

            Context.Session["AccessToken"] = token;
            Context.Session["AccessSecretToken"] = authToken;
        }

        public UserModel GetUserProfile()
        {
            var request = new RestRequest { Path = "~" };

            var credentials = new Hammock.Authentication.OAuth.OAuthCredentials
            {
                Type = Hammock.Authentication.OAuth.OAuthType.AccessToken,

                SignatureMethod = Hammock.Authentication.OAuth.OAuthSignatureMethod.HmacSha1,

                ParameterHandling = Hammock.Authentication.OAuth.OAuthParameterHandling.HttpAuthorizationHeader,

                ConsumerKey = "uir3aif0udas",

                ConsumerSecret = "K0Jp8whsJYBRWSIA",

                Token = Context.Session["AccessToken"].ToString(),

                TokenSecret = Context.Session["AccessSecretToken"].ToString(),

                Verifier = Context.Session["Verifier"].ToString()
            };

            var client = new RestClient
            {
                Authority = "http://api.linkedin.com/v1/people",
                Credentials = credentials,
                Method = WebMethod.Get
            };

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
                    case "site-standard-profile-request":
                        model.ProfileRequest = element.Value;
                        break;

                }
            }

            return model;
        }
    }
}