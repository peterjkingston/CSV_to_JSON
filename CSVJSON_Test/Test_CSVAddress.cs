using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CSVJSONLib;

namespace CSVJSON_Test
{
    [TestClass]
    public class Test_CSVAddress
    {
        [TestMethod]
        public void IsStandAlone_True_NoLabelLeft()
        {
            //Arrange
            CSVAddress csvAddress = new CSVAddress();

            //Act


            //Assert
            throw new NotImplementedException();
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
