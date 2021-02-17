using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVJSONLib;
using CSVJSON_Test.Dummy_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVJSON_Test
{
    [TestClass]
    public class Test_CSVReportReader
    {
        string _csvText = File.ReadAllText(@"..\..\Resources\Sample Report.csv");

        [TestMethod]
        public void GetProperties_ReturnsIReportContainer_GivenValidInput()
        {
            //Arrange
            string[] props = { "someProp" };
            string[] vals = { "someVal" };
            IReportContainer reportContainer = new Dummy_ReportContainer(props, vals);
            CSVReportReader reportReader = new CSVReportReader(_csvText, reportContainer);

            //Act
            IReportContainer actual = reportReader.GetProperties();

            //Assert
            Assert.IsNotNull(actual);
        }


        [TestMethod]
        public void GetProperties_CreatesReportContainer_GivenInvalidInput()
        {
            //Arrange
            string[] props = { "" };
            string[] vals = { "" };
            IReportContainer reportContainer = new Dummy_ReportContainer(props, vals);
            CSVReportReader reportReader = new CSVReportReader("", null);

            //Act
            IReportContainer actual = reportReader.GetProperties();

            //Assert
            Assert.IsNotNull(actual);
        }
    }
}
