using CSV_to_JSON;
using CSVJSONLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_to_JSON
{
    [TestClass]
    public class Test_Containerized_Thoughput
    {
        [TestMethod]
        public void Main_OutputsJsonFile_GivenValidCSVFile()
        {
            //Arrange
            string targetFilePath = @"..\..\Resources\Sample Report.csv";
            string newFile = Path.Combine(Path.GetDirectoryName(targetFilePath), @"Sample Report.json");
            bool expected = true;

            //Act
            Program.Main(new string[] { targetFilePath, "-o", newFile });
            bool actual = File.Exists(newFile);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Main_OutputsValidJson_GivenValidCSVFile()
        {
            //Arrange
            string targetFilePath = @"..\..\Resources\Sample Report.csv";
            string newFile = Path.Combine(Path.GetDirectoryName(targetFilePath), @"Sample Report.json");
            bool expected = true;

            //Act
            Program.Main(new string[] { targetFilePath, "-o", newFile });
            string jsonResult = JObject.Parse(File.ReadAllText(newFile)).ToString();
            bool actual = jsonResult != string.Empty;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Main_OutputsIntendedJson_GivenSampleFile()
        {
            //Arrange
            string targetFilePath = @"..\..\Resources\Sample Report.csv";
            string newFile = Path.Combine(Path.GetDirectoryName(targetFilePath), @"Sample Report.json");
            string expectedJsonPath = @"..\..\Resources\Expected Json.json";
            string expectedJson = File.ReadAllText(expectedJsonPath);
            bool expected = true;

            //Act
            Program.Main(new string[] { targetFilePath, "-o", newFile, "-e", "Windows-1252" });
            string resultJson = File.ReadAllText(newFile);
            bool actual = resultJson == expectedJson;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Main_OutputContainsSpecialCharacters_GivenSampleFile()
        {
            //Arrange
            string targetFilePath = @"..\..\Resources\Sample Report.csv";
            string newFile = Path.Combine(Path.GetDirectoryName(targetFilePath), @"Sample Report.json");
            Func<string, bool>[] checks =
            {
                (t) => { return t.Contains('°'); },
                (t) => { return t.Contains('“'); }
            };
            bool expected = true;

            //Act
            Program.Main(new string[] { targetFilePath, "-o", newFile, "-e", "Windows-1252" });
            string resultJson = File.ReadAllText(newFile);
            bool anyisFalse = checks.EachTrue(resultJson);
            
            bool actual = anyisFalse;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
