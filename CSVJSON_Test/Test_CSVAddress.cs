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
            CSVAddress csvAddress = new CSVAddress(8,1);
            bool expected = true;

            //Act
            bool actual = csvAddress.IsStandAlone(TEST_CONSTANTS.DUMMY_CSVSTRING_ARRAY);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        public void IsStandAlone_EdgeColumn_NoError()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress(7, 0);

            //Act
            bool success = csvAddress.IsStandAlone(TEST_CONSTANTS.DUMMY_CSVSTRING_ARRAY);


            //Assert
            Assert.IsTrue(success);
        }

		[TestMethod]
		public void IsStandAlone_EdgeRow_NoError()
		{
            //Arrange
            CSVAddress csvAddress = new CSVAddress(0, 4);

            //Act
            bool success = csvAddress.IsStandAlone(TEST_CONSTANTS.DUMMY_CSVSTRING_ARRAY);


            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void IsStandAlone_True_NoLabelAbove()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();
        }

        [TestMethod]
        public void IsStandAlone_True_NoLabelContained()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();
        }

        [TestMethod]
        public void IsStandAlone_False_LabelLeft()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();
        }

        [TestMethod]
        public void IsStandAlone_False_LabelTop()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();
        }

        [TestMethod]
        public void IsTopLabel_True_LabelAbove()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();
        }

        [TestMethod]
        public void IsTopLabel_False_NoLabel()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();
        }

        [TestMethod]
        public void IsTopLabel_True_LabelContained()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();
        }

		[TestMethod]
		public void IsTopLabel_EdgeRow_NoError()
		{
			//Arrange 

			//Act 

			//Assert
			Assert.Inconclusive();
		}

        [TestMethod]
        public void IsValid_True_RowWithinReport()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();

        }

        [TestMethod]
        public void IsValid_False_RowOutsideReport()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();

        }

        [TestMethod]
        public void IsValid_True_ColumnInReport()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();

        }

        [TestMethod]
        public void IsValid_False_ColumnOutsideReport()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();

        }

        [TestMethod]
        public void IsLeftLabel_True_LabelLeft()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();
    
        }

        [TestMethod]
        public void IsLeftLabel_False_NoLabel()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();

        }

		[TestMethod]
		public void IsLeftLabel_EdgeColumn_NoError()
		{
			//Arrange 

			//Act 

			//Assert
			Assert.Inconclusive();
		}

        [TestMethod]
        public void IsTableHeader_True_ObeysTableStandard()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();

        }

        [TestMethod]
        public void IsTableHeader_False_DisobeysTableStandard()
        {
            //Arrange


            //Act


            //Assert
            throw new NotImplementedException();

        }
    }
}
