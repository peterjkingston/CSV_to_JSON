using CSVJSON_Test.Dummy_Classes;
using CSVJSONLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSON_Test
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

        [TestMethod]
        public void AddPropertyStrStr_NoAdd_Str1IsEmpty()
        {
            //Arrange
            IUniqueNameProvider nameProvider = new Dummy_UniqueNameProvider();
            IReportContainer reportContainer = new ReportContainer(nameProvider);
            bool expected = true;

            //Act
            reportContainer.AddProperty("", "val");
            bool actual = reportContainer.Properties.Count == 0;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddPropertyStrStr_NoAdd_Str2IsEmpty()
        {
            //Arrange
            IUniqueNameProvider nameProvider = new Dummy_UniqueNameProvider();
            IReportContainer reportContainer = new ReportContainer(nameProvider);
            bool expected = true;

            //Act
            reportContainer.AddProperty("Prop", "");
            bool actual = reportContainer.Properties.Count == 0;

            //Assert
            Assert.AreEqual(expected, actual);
        }

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
    }
}
