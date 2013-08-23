using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetricsCorporation.Models;
using MetricsCorporation.BL;

namespace MetricsCorporationTest
{


    /// <summary>
    ///This is a test class for primRepositoryTest and is intended
    ///to contain all primRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class primRepositoryTest
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
        ///A test for GetSearchResults
        ///</summary>
        [TestMethod()]
        public void GetSearchResultsTest()
        {
            
            CompanyModel companyModel = new CompanyModel { CompanyName = "lon" }; // TODO: Initialize to an appropriate value
            string[] countyCollection = new string[0];
            string[] sicCodeCollection = new string[0];
            int[] employeeSizeCollection = new int[0];
            string expected = "LON COLVIN";
            string actual;
            actual = "";
            //var data = target.GetSearchResults(companyModel, countyCollection, sicCodeCollection, employeeSizeCollection);


            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
