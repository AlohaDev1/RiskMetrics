using System.Collections.Generic;
using System.Text;
using MetricsCorporation.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using MetricsCorporation.Models;

namespace MetricsCorporationTest
{


    /// <summary>
    ///This is a test class for UrlHelperTest and is intended
    ///to contain all UrlHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UrlHelperTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetGoogleEarthUrl
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Victor\\Documents\\GitHub\\ProspectBase\\Metrics\\MetricsCorporation", "/")]
        [UrlToTest("http://localhost:63692/")]
        public void GetGoogleEarthUrlTest()
        {
            var list = new List<string> { "1", "2", "3" };
            list.ToString();

            GoogleEarthModel model = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UrlHelper.GetGoogleEarthUrl(model);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


        [TestMethod()]
        public void ReverseString()
        {
            var a= Reverse("some string");
        }

        public string Reverse(string str)
        {
            var builder = new StringBuilder();
            var originalString = new StringBuilder(str);

            int length = originalString.Length - 1;


            for (int i = length; i >= 0; i--)
            {
                builder.Append(originalString[i]);
            }

            return builder.ToString();
        }
    }
}
