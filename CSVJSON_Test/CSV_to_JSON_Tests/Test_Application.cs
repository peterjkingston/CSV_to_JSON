using CSV_to_JSON;
using CSV_to_JSON.Init_Classes;
using CSVJSON_Test.Dummy_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_to_JSON_Tests
{
    [TestClass]
    public class Test_Application
    {
        private const string CSV_SAMPLE_PATH = @"..\..\Resources\Sample Report.csv";

        [TestMethod]
        public void Run_SendsStringResult_ValidInput()
        {
            //Arrange
            string targetPath = CSV_SAMPLE_PATH;
            Dummy_OutputHandler outputHandler = new Dummy_OutputHandler();
            Dummy_CSVReportReader reportReader = new Dummy_CSVReportReader();
            IApplication application = new Application(outputHandler, new Dummy_SwitchArgs(targetPath), reportReader);
            bool expected = true;

            //Act
            application.Run();
            bool actual = outputHandler.Output != string.Empty;


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Run_OutputsErrorMessage_NonExistentInputFilePath()
        {
            //Arrange
            string targetPath = @"..\SomeNonExistentPath.csv";
            Dummy_OutputHandler outputHandler = new Dummy_OutputHandler();
            Dummy_CSVReportReader reportReader = new Dummy_CSVReportReader();
            IApplication application = new Application(outputHandler, new Dummy_SwitchArgs(targetPath), reportReader);
            bool expected = true;

            //Act
            application.Run();
            bool actual = outputHandler.ErrorOutput != string.Empty;


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Run_OutputsErrorMessage_NonCSVFilePath()
        {
            //Arrange
            string targetPath = @"..\..\Resources\DUMMY_JSON_REPORT.json";
            Dummy_OutputHandler outputHandler = new Dummy_OutputHandler();
            Dummy_CSVReportReader reportReader = new Dummy_CSVReportReader();
            IApplication application = new Application(outputHandler, new Dummy_SwitchArgs(targetPath), reportReader);
            bool expected = true;

            //Act
            application.Run();
            bool actual = outputHandler.ErrorOutput != string.Empty;


            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
