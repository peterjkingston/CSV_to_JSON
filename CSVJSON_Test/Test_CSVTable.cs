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
            ICSVTable actual = CSVTable.FindTable(1, 1, sampleReport);

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
            ICSVTable actual = CSVTable.FindTable(1, 1, sampleReport);

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
            ICSVTable table = CSVTable.FindTable(1, 1, sampleReport);
            bool expected = true;

            //Act
            bool actual = table.Records.Count() == 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
