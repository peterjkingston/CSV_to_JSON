using CSVJSON_Test.Dummy_Classes;
using CSVJSONLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSON_Test.CSVJSONLib_Tests
{
    [TestClass]
    public class Test_ReportReader2
    {
        //string _csvText = File.ReadAllText(@"..\..\Resources\Sample Report.csv");

        //[TestMethod]
        //public void GetProperties_ReturnsIReportContainer_GivenValidInput()
        //{
        //    //Arrange
        //    string[] props = { "someProp" };
        //    string[] vals = { "someVal" };
        //    IReportContainer reportContainer = new Dummy_ReportContainer(props, vals);
        //    ICSVReportReader reportReader = new ReportReader2(reportContainer);
        //    reportReader.Read(_csvText);

        //    //Act
        //    IReportContainer actual = reportReader.GetProperties();

        //    //Assert
        //    Assert.IsNotNull(actual);
        //}


        //[TestMethod]
        //public void GetProperties_CreatesReportContainer_GivenInvalidInput()
        //{
        //    //Arrange
        //    string[] props = { "" };
        //    string[] vals = { "" };
        //    IReportContainer reportContainer = new Dummy_ReportContainer(props, vals);
        //    ICSVReportReader reportReader = new ReportReader2(null);
        //    reportReader.Read("");

        //    //Act
        //    IReportContainer actual = reportReader.GetProperties();

        //    //Assert
        //    Assert.IsNotNull(actual);
        //}
    }
}
