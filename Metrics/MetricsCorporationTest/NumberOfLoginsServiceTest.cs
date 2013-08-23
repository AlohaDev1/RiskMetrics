using MetricsCorporation.BL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MetricsCorporation.BL.Mapping;
using MetricsCorporation.Models;

namespace MetricsCorporationTest
{


    /// <summary>
    ///This is a test class for NumberOfLoginsServiceTest and is intended
    ///to contain all NumberOfLoginsServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NumberOfLoginsServiceTest
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
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            IMapper mapper = new MetricsMapper();
            var target = new NumberOfLoginsService(mapper);
            NumberOfLoginsModel value = new NumberOfLoginsModel { LoginDate = DateTime.Now, UserId = 1 };
            NumberOfLoginsModel expected = new NumberOfLoginsModel { LoginDate = DateTime.Now, UserId = 1, Id = 1, Count = 1 };
            NumberOfLoginsModel actual;
            actual = target.Create(value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
