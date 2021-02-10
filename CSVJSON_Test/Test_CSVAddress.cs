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
            CSVAddress csvAddress = new CSVAddress(0,1);
            string[,] table = 
            {
                {"","SomeData","" }
            };
            bool expected = true;

            //Act
            bool actual = csvAddress.IsStandAlone(table);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        public void IsStandAlone_EdgeColumn_NoError()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0, 0);
            string[,] table =  
            {
                { "SomeData" }
            };

            //Act
            bool success = csvAddress.IsStandAlone(table); ;

            //Assert
            Assert.IsTrue(success);
        }

		[TestMethod]
		public void IsStandAlone_EdgeRow_NoError()
		{
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0, 0);
            string[,] table =
            {
                { "SomeData" }
            };

            //Act
            bool success = csvAddress.IsStandAlone(table);


            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void IsStandAlone_True_NoLabelAbove()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(1, 0);
            string[,] table =
            {
                { "" },
                { "SomeData" }
            };
            bool expected = true;

            //Act
            bool actual = csvAddress.IsStandAlone(table);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsStandAlone_True_NoLabelContained()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0,0);
            string[,] table =
            {
                { "SomeLabel" }
            };
            bool expected = true;

            //Act
            bool actual = csvAddress.IsStandAlone(table);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsStandAlone_False_LabelLeft()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0, 1);
            string[,] table =
            {
                { "prop", "val" }
            };
            bool expected = false;

            //Act
            bool actual = csvAddress.IsStandAlone(table);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsStandAlone_False_LabelAbove()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(1,0);
            string[,] table =
            {
                { "prop" },
                { "val" }
            };
            bool expected = false;

            //Act
            bool actual = csvAddress.IsStandAlone(table);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsTopLabel_True_LabelAbove()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0, 0);
            string[,] table =
            {
                { "prop" },
                { "val" }
            };
            bool expected = false;
            
            //Act
            bool actual = csvAddress.IsTopLabel(table);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsTopLabel_False_NoLabel()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(1,0);
            string[,] table =
            {
                { "" },
                { "val" }
            };
            bool expected = false;

            //Act
            bool actual = csvAddress.IsTopLabel(table);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsTopLabel_True_LabelContained()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(1,0);
            string[,] table =
            {
                { "prop" },
                { "SomeProp:val" }
            };
            bool expected = true;

            //Act
            bool actual = csvAddress.IsTopLabel(table);

            //Assert
            Assert.AreEqual(expected,actual);
        }

		[TestMethod]
		public void IsTopLabel_EdgeRow_NoError()
		{
            //Arrange 
            CSVAddress csvAddress = new CSVAddress(0,0);
            string[,] table =
            {
                { "prop" },
                { "val" }
            };

            //Act 
            bool success = csvAddress.IsTopLabel(table);

			//Assert
			Assert.IsTrue(success);
		}

        [TestMethod]
        public void IsValid_True_RowWithinReport()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0,0);
            string[,] table =
            {
                { "" }
            };
            bool expected = true;

            //Act
            bool actual = csvAddress.IsValid(table);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IsValid_False_RowOutsideReport()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(-1, 0);
            string[,] table =
            {
                { "" }
            };
            bool expected = false;

            //Act
            bool actual = csvAddress.IsValid(table);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void IsValid_True_ColumnInReport()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0, 0);
            string[,] table =
            {
                { "" }
            };
            bool expected = true;

            //Act
            bool actual = csvAddress.IsValid(table);

            //Assert
            Assert.AreEqual(expected,actual);

        }

        [TestMethod]
        public void IsValid_False_ColumnOutsideReport()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0, -1);
            string[,] table =
            {
                { "" }
            };
            bool expected = false;

            //Act
            bool actual = csvAddress.IsValid(table);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsLeftLabel_True_LabelLeft()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0, 0);
            string[,] table =
            {
                { "prop", "val" }
            };
            bool expected = true;

            //Act
            bool actual = csvAddress.IsLeftLabel(table);

            //Assert
            Assert.AreEqual(expected,actual);
    
        }

        [TestMethod]
        public void IsLeftLabel_False_NoLabel()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0, 0);
            string[,] table =
            {
                { "", "val" }
            };
            bool expected = false;

            //Act
            bool actual = csvAddress.IsLeftLabel(table);

            //Assert
            Assert.AreEqual(expected, actual);
        }

		[TestMethod]
		public void IsLeftLabel_EdgeColumn_NoError()
		{
            //Arrange 
            CSVAddress csvAddress = new CSVAddress(0, 0);
            string[,] table =
            {
                { "prop", "val" }
            };

            //Act 
            bool success = csvAddress.IsLeftLabel(table);

            //Assert
            Assert.IsTrue(success);
		}

        //02-09-21 PK:Test more table standards more thurourghly
        [TestMethod]
        public void IsTableHeader_True_ObeysTableStandard()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(1, 0);
            string[,] table =
            {
                { "","","","" },
                { "Prop","Val","Dt","" },
                { "0","","","" },
                { "ice","cream","0","" }
            };
            bool expected = true;

            //Act
            bool actual = csvAddress.IsTableHeader(table); ;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //02-09-21 PK:Test more table standards more thurourghly
        [TestMethod]
        public void IsTableHeader_False_DisobeysTableStandard()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0,0);
            string[,] table =
            {
                { "","","","" },
                { "Prop","Val","","" },
                { "0","","","" },
                { "ice","cream","0","" }
            };
            bool expected = false;

            //Act
            bool actual = csvAddress.IsTableHeader(table);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}