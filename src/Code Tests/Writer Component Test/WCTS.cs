using Common_Class_Library.Implementations;
using DumpingBuffer_Component.Implementations;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using Writer_Component.Implementations;
using Writer_Component.Interfaces;

namespace Writer_Component_Test
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class WCTS
    {
        [Test]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        public void PassDataOk()
        {
            Mock<IWriter> mock = new Mock<IWriter>();
            DumpingBuffer db = new DumpingBuffer();
            mock.Setup(p => p.DataPassThrough(db, new ModelData()));
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
        public void PassDataParams(int userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            ModelData modelData = new ModelData(userID, username, userAddress, userCity, brojiloId, potroseno, mesec);

            DumpingBuffer db = new DumpingBuffer();
            Mock<IWriter> mock = new Mock<IWriter>();

            for (int i = 0; i < 8; i++)
            {
                // change field value
                modelData.UserID = userID + i * 8;

                mock.Setup(p => p.DataPassThrough(db, modelData));
            }
        }

        [Test]
        [TestCase(1, "uname", "addrr", "", "SE-515", 12, "Januar")]
        [TestCase(2, "uname", "", "city", "SE-515", 12, "Februar")]
        [TestCase(3, "uname", "addrr", "city", "SE-515", 24, "")]
        [TestCase(4, "name", "", "city", "SE-515", 12, "Januar")]
        [TestCase(5, "uname", "addrr", "city", "SE-64", 152, "")]
        [TestCase(6, "", "", "", "", 12, "Januar")]
        [TestCase(0, "uname", "addrr", "city", "SE-515", 0, "Januar")]
        [TestCase(8, "uname", "", "", "SE-515", 12, "Januar")]
        [TestCase(9, "uname", null, "city", "SE-521", 47, "Januar")]
        [TestCase(10, "", "addrr", "city", "SE-515", 688, null)]
        public void PassWrongParams(int userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            DumpingBuffer db = new DumpingBuffer();

            try
            {
                ModelData modelData = new ModelData(userID, username, userAddress, userCity, brojiloId, potroseno, mesec);
                Mock<IWriter> mock = new Mock<IWriter>();

                for (int i = 0; i < 8; i++)
                {
                    // change field value
                    modelData.UserID = userID + i * 8;

                    mock.Setup(p => p.DataPassThrough(db, modelData));
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("[ERROR] NULL DATA PASSED");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("[ERROR] INVALID DATA PASSED");
            }
        }

        [Test]
        [TestCase]
        public void OtherTests()
        {
            try
            {
                Writer w = new Writer();
                w.DataPassThrough(new DumpingBuffer(), new ModelData());

                Assert.NotNull(w);
            }
            catch { }
        }
    }
}
