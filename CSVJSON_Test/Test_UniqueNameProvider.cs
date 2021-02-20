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
    public class Test_UniqueNameProvider
    {
        [TestMethod]
        public void GetUniqueNameStrArryStr_NoRepeat()
        {
            //Arrange
            string[] dummyNames = {"name1", "name2", "name3" };
            IUniqueNameProvider nameProvider = new UniqueNameProvider();
            bool expected = false;

            //Act
            string resultName = nameProvider.GetUniqueName(dummyNames, "name1");
            bool actual = dummyNames.Contains(resultName);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetUniqueNameStrArryStr_NoUnnessecaryRename()
        {
            //Arrange
            string hardName = "name4";
            string[] dummyNames = { "name1", "name2", "name3" };
            IUniqueNameProvider nameProvider = new UniqueNameProvider();
            bool expected = true;

            //Act
            string resultName = nameProvider.GetUniqueName(dummyNames, hardName);
            bool actual = resultName == hardName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUniqueNameStrArry_NoRepeat()
        {
            //Arrange
            string[] dummyNames = { "name1", "name2", "name3" };
            IUniqueNameProvider nameProvider = new UniqueNameProvider();
            bool expected = false;

            //Act
            string resultName = nameProvider.GetUniqueName(dummyNames);
            bool actual = dummyNames.Contains(resultName);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
