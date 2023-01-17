using Common_Class_Library.Implementations;
using NUnit.Framework;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Common_Class_Library_Test
{
    [ExcludeFromCodeCoverage]
    public class CCLT
    {
        [Test]
        [TestCase()]
        public void GetConnectionTest()
        {
            using (IDbConnection konekcija = Connection.GetConnection())
            {
                konekcija.Open();

                // Konekcija je otvorena
                Assert.NotNull(konekcija);
            }
        }

        [Test]
        [TestCase()]
        public void TestModelData()
        {
            ModelData modelData = new ModelData();

            Assert.NotNull(modelData);
        }

        [Test]
        [TestCase(1, "uname", "addrr", "city", "SE-515", 12, "Januar")]
        [TestCase(2, "uname", "addrr", "city", "SE-515", 12, "Februar")]
        [TestCase(3, "uname", "addrr", "city", "SE-515", 24, "Mart")]
        [TestCase(4, "name", "addrr", "city", "SE-515", 12, "Januar")]
        [TestCase(5, "uname", "addrr", "city", "SE-64", 152, "Januar")]
        [TestCase(6, "uname", "address", "city", "SE-515", 12, "Januar")]
        [TestCase(7, "uname", "addrr", "city", "SE-515", 411, "Januar")]
        [TestCase(8, "uname", "addrr", "city square", "SE-515", 12, "Januar")]
        [TestCase(9, "uname", "addrr", "city", "SE-521", 47, "Januar")]
        [TestCase(10, "uname", "addrr", "city", "SE-515", 688, "Januar")]
        public void TestModelDataParams(int userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            ModelData modelData = new ModelData(userID, username, userAddress, userCity, brojiloId, potroseno, mesec);

            Assert.NotNull(modelData);
        }


        [Test]
        [TestCase(1, null, "addrr", "city", "SE-515", 12, "Januar")]
        [TestCase(2, "uname", null, "city", "SE-515", 12, "Februar")]
        [TestCase(3, "uname", "addrr", null, "SE-515", 24, "Mart")]
        [TestCase(4, "name", "addrr", "city", null, 12, "Januar")]
        [TestCase(5, "uname", "addrr", "city", null, 152, "Januar")]
        [TestCase(6, null, "address", "city", "SE-515", 12, "Januar")]
        [TestCase(7, "uname", "addrr", "city", null, 411, "Januar")]
        [TestCase(8, "uname", "addrr", "city square", "SE-515", 12, null)]
        [TestCase(9, null, null, null, null, 47, null)]
        [TestCase(10, null, "addrr", "city", null, 5, "Januar")]
        [TestCase(14, null, "addrr", "city", null, 5, "Januar")]

        public void TestModelDataParamsNull(int userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ModelData modelData = new ModelData(userID, username, userAddress, userCity, brojiloId, potroseno, mesec);

            });
        }

        [Test]
        [TestCase(1, "", "addrr", "city", "SE-515", 12, "Januar")]
        [TestCase(2, "uname", "", "city", "SE-515", 12, "Februar")]
        [TestCase(3, "uname", "addrr", "", "SE-515", 24, "Mart")]
        [TestCase(4, "name", "addrr", "city", "", 12, "Januar")]
        [TestCase(5, "uname", "addrr", "", "SE-64", 152, "Januar")]
        [TestCase(6, "", "address", "city", "SE-515", 12, "")]
        [TestCase(7, "uname", "addrr", "", "SE-515", 411, "Januar")]
        [TestCase(8, "uname", "addrr", "", "SE-515", 12, "Januar")]
        [TestCase(9, "uname", "", "city", "SE-521", 47, "Januar")]
        [TestCase(10, "", "", "", "", 688, "")]

        public void TestModelDataEmptyParams(int userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ModelData modelData = new ModelData(userID, username, userAddress, userCity, brojiloId, potroseno, mesec);

            });
        }

        [Test]
        [TestCase()]
        public void PropertyTests()
        {
            ModelData modelData = new ModelData();

            modelData.UserID = 1;
            modelData.Username = "test";
            modelData.UserCity = "test";
            modelData.UserAddress = "test";
            modelData.BrojiloId = "test";
            modelData.Mesec = "test";
            modelData.Potroseno = 1;

            Assert.AreEqual(1, modelData.UserID);
            Assert.AreEqual("test", modelData.Username);
            Assert.AreEqual("test", modelData.UserCity);
            Assert.AreEqual("test", modelData.UserAddress);
            Assert.AreEqual("test", modelData.BrojiloId);
            Assert.AreEqual("test", modelData.Mesec);
            Assert.AreEqual(1, modelData.Potroseno);
        }

        [Test]
        [TestCase()]
        public void EqualsTestOk()
        {
            ModelData modelData = new ModelData();
            ModelData modelData1 = new ModelData();

            Assert.AreEqual(true, modelData.Equals(modelData1));
        }
    }
}
