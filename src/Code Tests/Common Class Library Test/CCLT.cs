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

    }
}
