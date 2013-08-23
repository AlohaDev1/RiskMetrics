using System.Configuration;
using MetricsCorporation.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using MetricsCorporation.Models;
using System.Collections.Generic;

namespace MetricsCorporationTest
{
    
    
    /// <summary>
    ///This is a test class for JigsawHelperTest and is intended
    ///to contain all JigsawHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JigsawHelperTest
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
        ///A test for GetCompanyId
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Victor\\Documents\\GitHub\\ProspectBase\\Metrics\\MetricsCorporation", "/")]
        [UrlToTest("http://localhost:63692/")]
        public void GetCompanyIdTest()
        {
            ConfigurationManager.AppSettings["ConnectionInfo"] = "ek49phfby0cs";


            string companyName = "Sub Technologies Inc";
            string expected = "3987840";
            string actual;
            actual = JigsawHelper.GetCompanyId(companyName);
            Assert.AreEqual(expected, actual);

            companyName = "FOUR G CONSTRUCTION INC";
            expected = "";
            actual = JigsawHelper.GetCompanyId(companyName);
            Assert.AreEqual(expected, actual);

            companyName = "COMET INDUSTRIES INC";
            expected = "1258384";
            actual = JigsawHelper.GetCompanyId(companyName);
            Assert.AreEqual(expected, actual);

            companyName = "AMPLEFORTH ENTERPRISES INC";
            expected = "";
            actual = JigsawHelper.GetCompanyId(companyName);
            Assert.AreEqual(expected, actual);

            companyName = "AMERICAN DEHYDRATED FOODS INC";
            expected = "204339";
            actual = JigsawHelper.GetCompanyId(companyName);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetContacts
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Victor\\Documents\\GitHub\\ProspectBase\\Metrics\\MetricsCorporation", "/")]
        [UrlToTest("http://localhost:63692/")]
        public void GetContactsTest()
        {
            ConfigurationManager.AppSettings["ConnectionInfo"] = "ek49phfby0cs";

            string companyName = "American Dehydrated Foods, Inc.";
            string expectedCompanyId = "204339";
            string actualCompanyId;
            actualCompanyId = JigsawHelper.GetCompanyId(companyName);
            Assert.AreEqual(expectedCompanyId, actualCompanyId);


            string companyId = actualCompanyId;
            int expected = 16;
            int actual;
            var model = JigsawHelper.GetContacts(companyId);

            actual = model.Count;

            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }



        /// <summary>
        ///A test for GetPurchasedContact
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Victor\\Documents\\GitHub\\ProspectBase\\Metrics\\MetricsCorporation", "/")]
        [UrlToTest("http://localhost:63692/")]
        public void GetPurchasedContactTest()
        {
            ConfigurationManager.AppSettings["ConnectionInfo"] = "ek49phfby0cs";

            ConfigurationManager.AppSettings["JigsawUserName"] = "kmccarthy@datalister.com";

            ConfigurationManager.AppSettings["JigsawPassword"] = "metrics1595";


            string companyName = "American Dehydrated Foods, Inc.";
            string expectedCompanyId = "204339";
            string actualCompanyId;
            actualCompanyId = JigsawHelper.GetCompanyId(companyName);
            Assert.AreEqual(expectedCompanyId, actualCompanyId);


            string companyId = actualCompanyId;
            int expected = 16;
            int actual;
            var model = JigsawHelper.GetContacts(companyId);

            actual = model.Count;

            Assert.AreEqual(expected, actual);

            long contactId = model[0].ContactId;
            string email = "dpfaff@adfinc.com";
            string address = "PO BOX 4087";
            string phone = "+1.417.881.7755";
            

            var contactInfo = JigsawHelper.GetPurchasedContact(contactId);


            Assert.AreEqual(email, contactInfo.Email); 
            Assert.AreEqual(address, contactInfo.Address);
            Assert.AreEqual(phone, contactInfo.Phone);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
