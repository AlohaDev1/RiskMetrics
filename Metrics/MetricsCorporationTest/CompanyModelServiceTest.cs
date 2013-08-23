using MetricsCorporation.BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Models;
using System.Collections.Generic;

namespace MetricsCorporationTest
{


    /// <summary>
    ///This is a test class for CompanyModelServiceTest and is intended
    ///to contain all CompanyModelServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompanyModelServiceTest
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
        ///A test for GetAllByCompanyModel
        ///</summary>
        [TestMethod()]
        public void GetAllByCompanyModelTest()
        {
            IMapper mapper = new MetricsMapper(); // TODO: Initialize to an appropriate value
            CompanyModelService target = new CompanyModelService(mapper); // TODO: Initialize to an appropriate value
            CompanyModel model = new CompanyModel { UserId = 1, EmployeeSize = "0,7" }; // TODO: Initialize to an appropriate value
            IEnumerable<CompanyModel> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<CompanyModel> actual;
            actual = target.GetAllByCompanyModel(model);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
