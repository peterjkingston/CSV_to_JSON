using CSVJSON_Test.Dummy_Classes;
using CSVJSONLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib_Tests
{
    [TestClass]
    public class Test_ReportContainer
    {
        [TestMethod]
        public void AddTable_AddsToContainer()
        {
            //Arrange
            ICSVTable table = new Dummy_CSVTable();
            IUniqueNameProvider nameProvider = new Dummy_UniqueNameProvider();
            IReportContainer reportContainer = new ReportContainer(nameProvider);
            bool expected = true;

            //Act
            reportContainer.AddTable(table);
            bool actual = reportContainer.Tables.Count == 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTable_NoAdd_TableIsNull()
        {
            ICSVTable table = null;
            IUniqueNameProvider nameProvider = new Dummy_UniqueNameProvider();
            IReportContainer reportContainer = new ReportContainer(nameProvider);
            bool expected = true;

            //Act
            reportContainer.AddTable(table);
            bool actual = reportContainer.Tables.Count == 0;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddPropertyStrStr_AddsToContainer()
        {
            //Arrange
            IUniqueNameProvider nameProvider = new Dummy_UniqueNameProvider();
            IReportContainer reportContainer = new ReportContainer(nameProvider);
            bool expected = true;

            //Act
            reportContainer.AddProperty("Prop", "val");
            bool actual = reportContainer.Properties.Count == 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void AddPropertyStrStr_NoAdd_Str1IsEmpty()
        //{
        //    //Arrange
        //    IUniqueNameProvider nameProvider = new Dummy_UniqueNameProvider();
        //    IReportContainer reportContainer = new ReportContainer(nameProvider);
        //    bool expected = true;

        //    //Act
        //    reportContainer.AddProperty("", "val");
        //    bool actual = reportContainer.Properties.Count == 0;

        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void AddPropertyStrStr_NoAdd_Str2IsEmpty()
        //{
        //    //Arrange
        //    IUniqueNameProvider nameProvider = new Dummy_UniqueNameProvider();
        //    IReportContainer reportContainer = new ReportContainer(nameProvider);
        //    bool expected = true;

        //    //Act
        //    reportContainer.AddProperty("Prop", "");
        //    bool actual = reportContainer.Properties.Count == 0;

        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        public void AddPropertyStr_AddsToContainer()
        {
            //Arrange
            IUniqueNameProvider nameProvider = new Dummy_UniqueNameProvider();
            IReportContainer reportContainer = new ReportContainer(nameProvider);
            bool expected = true;

            //Act
            reportContainer.AddProperty("val");
            bool actual = reportContainer.Properties.Count == 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddPropertyStr_NoAdd_StrIsEmpty()
        {
            //Arrange
            IUniqueNameProvider nameProvider = new Dummy_UniqueNameProvider();
            IReportContainer reportContainer = new ReportContainer(nameProvider);
            bool expected = true;

            //Act
            reportContainer.AddProperty("");
            bool actual = reportContainer.Properties.Count == 0;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToJSON_IncludesAddedProperties()
        {
            //Arrange
            string sample = "{\n"+
              "\"name\": \"report\",\n"+
              "\"measure\": \"pounds\"\n"+
              "}";
            JObject sampleObject = JObject.Parse(sample);
            IReportContainer reportContainer = new ReportContainer(new Dummy_UniqueNameProvider());
            reportContainer.AddProperty("name", "report");
            reportContainer.AddProperty("measure", "pounds");
            bool expected = true;

            //Act
            string jsonResult = reportContainer.ToJSON();

            bool actual = sampleObject.ToString() == jsonResult;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToJSON_IncludesAddedTables()
        {
            //Arrange
            string sample = "{\"table_1\":[{\"name\":\"sam\", \"age\":42},{\"name\":\"tom\", \"age\":77}],\"table_2\":[{\"name\":\"sam\", \"favorite-Food\":\"pizza\"},{\"name\":\"tom\", \"favorite-Food\":\"apples\"}]}";
            JObject sampleObject = JObject.Parse(sample);
            IReportContainer reportContainer = new ReportContainer(new Dummy_UniqueNameProvider());
            ICSVTable table_1 = new Dummy_CSVTable("[{\"name\":\"sam\", \"age\":42},{\"name\":\"tom\", \"age\":77}]");
            ICSVTable table_2 = new Dummy_CSVTable("[{\"name\":\"sam\", \"favorite-Food\":\"pizza\"},{\"name\":\"tom\", \"favorite-Food\":\"apples\"}]");
            reportContainer.AddTable("table_1", table_1);
            reportContainer.AddTable("table_2", table_2);
            bool expected = true;

            //Act
            string resultJSON = reportContainer.ToJSON();
            bool actual = resultJSON == sampleObject.ToString();

            //Assert
            Assert.AreEqual(expected,actual);
        }
    }
}
