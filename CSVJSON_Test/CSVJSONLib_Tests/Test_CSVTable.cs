using CSVJSON_Test.Dummy_Classes;
using CSVJSONLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib_Tests
{
    [TestClass]
    public class Test_CSVTable
    {
        [TestMethod]
        public void FindTable_CSVTable_MatchesTableStandard()
        {
            //Arrange
            string[,] sampleReport =
            {
                { "",""        ,""       ,""          , "" },
                { "", "Header1","Header2", "Header3"  , "" },
                { "", ""       ,"Spanky" , "0"        , "" },
                { "", "lol"    ,"Judas"  , "SaidFrank", "" },
                { "",""        ,""       ,""          , "" }
            };

            //Act
            ICSVTable actual = CSVTable.FindTable(new Dummy_UniqueNameProvider(),1, 1, sampleReport);

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void FindTable_Null_DoesNotMatchTableStandard()
        {
            //Arrange
            string[,] sampleReport =
            {
                { "",""        ,""       ,""          , "" },
                { "", "Header1","Header2", "Header3"  , "" },
                { "", ""       ,"0"      , "0"        , "" },
                { "", "lol"    ,"Judas"  , "SaidFrank", "" },
                { "",""        ,""       ,""          , "" }
            };

            //Act
            ICSVTable actual = CSVTable.FindTable(new Dummy_UniqueNameProvider(),1, 1, sampleReport);

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void FindTable_BlankAndZeroRows_Ignored()
        {
            //Arrange
            string[,] sampleReport =
            {
                { "",""        ,""       ,""          , "" },
                { "", "Header1","Header2", "Header3"  , "" },
                { "", ""       ,"Jank"   , "0"        , "" },
                { "", ""       ,"0"      , "0"        , "" },
                { "",""        ,""       ,""          , "" }
            };
            ICSVTable table = CSVTable.FindTable(new Dummy_UniqueNameProvider(),1, 1, sampleReport);
            bool expected = true;

            //Act
            bool actual = table.Records.Count() == 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToJSON_RetrunsJSONArray()
        {
            //Arrange
            string[,] sampleReport =
            {
                { "",""        ,""       ,""          , "" },
                { "", "Header1","Header2", "Header3"  , "" },
                { "", ""       ,"Jank"   , "0"        , "" },
                { "", ""       ,"0"      , "0"        , "" },
                { "",""        ,""       ,""          , "" }
            };
            IJSONConvertable table = CSVTable.FindTable(new Dummy_UniqueNameProvider(),1, 1, sampleReport);
            string jsonSample = "[{\"Header1\":\"\",  \"Header2\":\"Jank\", \"Header3\":\"0\"}]";
            JToken jsonSampleArray = JArray.Parse(jsonSample);
            bool expected = true;

            //Act
            bool actual = jsonSampleArray.ToString() == table.AsJObject().ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
