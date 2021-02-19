using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CSVJSONLib;
using CSVJSON_Test.Resources;

namespace CSVJSON_Test
{
    [TestClass]
    public class Test_CSVAddress
    {
        [TestMethod]
        public void IsStandAlone_True_NoLabelLeft()
        {
            //Arrange
            string[,] table = 
            {
                {"","SomeData","" }
            };
            ICSVAddress csvAddress = new CSVAddress(0, 1, table);

            bool expected = true;

            //Act
            bool actual = csvAddress.IsStandAlone();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        public void IsStandAlone_EdgeColumn_NoError()
        {
            //Arrange
            string[,] table =  
            {
                { "SomeData" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);

            //Act
            bool success = csvAddress.IsStandAlone(); ;

            //Assert
            Assert.IsTrue(success);
        }

		[TestMethod]
		public void IsStandAlone_EdgeRow_NoError()
		{
            //Arrange
            string[,] table =
            {
                { "SomeData" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);

            //Act
            bool success = csvAddress.IsStandAlone();


            //Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IsStandAlone_True_NoValueBelow()
        {
            //Arrange
            string[,] table =
            {
                { "" },
                { "SomeData" },
                { "" }
            };
            CSVAddress csvAddress = new CSVAddress(1, 0, table);
            bool expected = true;

            //Act
            bool actual = csvAddress.IsStandAlone();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsStandAlone_True_NoLabelContained()
        {
            //Arrange
            string[,] table =
            {
                { "SomeLabel" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);
            bool expected = true;

            //Act
            bool actual = csvAddress.IsStandAlone();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsStandAlone_False_ValueRight()
        {
            //Arrange
            string[,] table =
            {
                { "prop", "val" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);
            bool expected = false;

            //Act
            bool actual = csvAddress.IsStandAlone();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsStandAlone_False_ValueBelow()
        {
            //Arrange
            string[,] table =
            {
                { "prop" },
                { "val" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);
            bool expected = false;

            //Act
            bool actual = csvAddress.IsStandAlone();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsTopLabel_True_ValueBelow()
        {
            //Arrange
            string[,] table =
            {
                { "prop" },
                { "val" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);
            bool expected = true;
            
            //Act
            bool actual = csvAddress.IsTopLabel();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsTopLabel_False_NoValue()
        {
            //Arrange
            string[,] table =
            {
                { "" },
                { "val" },
                { "" }
            };
            CSVAddress csvAddress = new CSVAddress(1, 0, table);
            bool expected = false;

            //Act
            bool actual = csvAddress.IsTopLabel();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsTopLabel_True_LabelContained()
        {
            //Arrange
            string[,] table =
            {
                { "prop" },
                { "SomeProp:val" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);
            bool expected = true;

            //Act
            bool actual = csvAddress.IsTopLabel();

            //Assert
            Assert.AreEqual(expected,actual);
        }

		[TestMethod]
		public void IsTopLabel_EdgeRow_NoError()
		{
            //Arrange 
            string[,] table =
            {
                { "prop" },
                { "val" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);

            //Act 
            bool success = csvAddress.IsTopLabel();

			//Assert
			Assert.IsTrue(true);
		}

        [TestMethod]
        public void IsValid_True_RowWithinReport()
        {
            //Arrange
            string[,] table =
            {
                { "" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);
            bool expected = true;

            //Act
            bool actual = csvAddress.IsValid();

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IsValid_False_RowOutsideReport()
        {
            //Arrange
            string[,] table =
            {
                { "" }
            };
            CSVAddress csvAddress = new CSVAddress(-1, 0, table);
            bool expected = false;

            //Act
            bool actual = csvAddress.IsValid();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsValid_True_ColumnInReport()
        {
            //Arrange
            string[,] table =
            {
                { "" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);
            bool expected = true;

            //Act
            bool actual = csvAddress.IsValid();

            //Assert
            Assert.AreEqual(expected,actual);

        }

        [TestMethod]
        public void IsValid_False_ColumnOutsideReport()
        {
            //Arrange
            string[,] table =
            {
                { "" }
            };
            CSVAddress csvAddress = new CSVAddress(0, -1, table);
            bool expected = false;

            //Act
            bool actual = csvAddress.IsValid();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsLeftLabel_True_ValueRight()
        {
            //Arrange
            string[,] table =
            {
                { "prop", "val" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);
            bool expected = true;

            //Act
            bool actual = csvAddress.IsLeftLabel();

            //Assert
            Assert.AreEqual(expected,actual);
    
        }

        [TestMethod]
        public void IsLeftLabel_False_NoValue()
        {
            //Arrange
            string[,] table =
            {
                { "", "prop", "" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 1, table);
            bool expected = false;

            //Act
            bool actual = csvAddress.IsLeftLabel();

            //Assert
            Assert.AreEqual(expected, actual);
        }

		[TestMethod]
		public void IsLeftLabel_EdgeColumn_NoError()
		{
            //Arrange 
            string[,] table =
            {
                { "prop", "val" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);

            //Act 
            bool success = csvAddress.IsLeftLabel();

            //Assert
            Assert.IsTrue(true);
		}

        //02-09-21 PK:Test more table standards more thurourghly
        [TestMethod]
        public void IsTableHeader_True_ObeysTableStandard()
        {
            //Arrange
            string[,] table =
            {
                { "","","","" },
                { "Prop","Val","Dt","" },
                { "0","","","" },
                { "ice","cream","0","" }
            };
            CSVAddress csvAddress = new CSVAddress(1, 0, table);
            bool expected = true;

            //Act
            bool actual = csvAddress.IsTableHeader(); 

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //02-09-21 PK:Test more table standards more thurourghly
        [TestMethod]
        public void IsTableHeader_False_DisobeysTableStandard()
        {
            //Arrange
            string[,] table =
            {
                { "","","","" },
                { "Prop","Val","","" },
                { "0","","","" },
                { "ice","cream","0","" }
            };
            CSVAddress csvAddress = new CSVAddress(0, 0, table);
            bool expected = false;

            //Act
            bool actual = csvAddress.IsTableHeader();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}