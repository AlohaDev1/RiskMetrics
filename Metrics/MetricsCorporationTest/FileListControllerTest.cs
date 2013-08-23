﻿using MetricsCorporation.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using MetricsCorporation.Models;
using MetricsCorporation.BL.Interfaces;
using System.Net.Http;

namespace MetricsCorporationTest
{


    /// <summary>
    ///This is a test class for FileListControllerTest and is intended
    ///to contain all FileListControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FileListControllerTest
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
        ///A test for Put
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Victor\\Documents\\GitHub\\ProspectBase\\Metrics\\MetricsCorporation", "/")]
        [UrlToTest("http://localhost:51607/")]
        public void PutTest()
        {
            
            ICrud<FileListModel> fileListService = null; // TODO: Initialize to an appropriate value
            FileListController target = new FileListController(fileListService); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            FileListModel user = new FileListModel
            {
                UserName = "jmc1",
                ActivationDate = null,
                Admin = false,
                CanexportList = false,
                CompanyName = "Risk Metrics",
                ExpirationDate = null,
                FilePath = @"db\SC-JordanMcCallum.mdb",
                LastLoginDate = null,
                MaxReportViewsPerMonth = 0,
                Name = null,
                Password = "metrics1595",
                RenewalDate = null,
                States = "SC"
            };


            HttpResponseMessage expected = null; // TODO: Initialize to an appropriate value
            HttpResponseMessage actual;
            //actual = target.Put(id, model);
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Victor\\Documents\\GitHub\\ProspectBase\\Metrics\\MetricsCorporation", "/")]
        [UrlToTest("http://localhost:51607/")]
        public void DeleteTest()
        {
            ICrud<FileListModel> fileListService = null; // TODO: Initialize to an appropriate value
            FileListController target = new FileListController(fileListService); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            HttpResponseMessage expected = null; // TODO: Initialize to an appropriate value
            HttpResponseMessage actual;
            actual = target.Delete(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
