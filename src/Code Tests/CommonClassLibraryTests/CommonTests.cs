using Common_Class_Library.Implementations;
using NUnit.Framework;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace CommonClassLibraryTests
{
    public class CommonTests
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
        public void TestModelDataParams(int userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            ModelData modelData = new ModelData(userID, username, userAddress, userCity, brojiloId, potroseno, mesec);

            Assert.NotNull(modelData);
        }
    }
}
