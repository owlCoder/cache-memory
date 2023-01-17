﻿using Common_Class_Library.Implementations;
using Historical_Component.Implementations;
using Historical_Component.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace HistoricalTests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class Class1
    {
        [Test]
        [TestCase()]
        public void GetAllCorrect()
        {
            Historical hc = new Historical();

            Assert.DoesNotThrow(() =>
            {
                List<ModelData> list = hc.GetAllDataFromDataBase().ToList();
            });
        }
        [Test]
        [TestCase("userId", "12")]
        [TestCase("userName", "dani")]
        [TestCase("userAddress", "Alekse Santica 4")]
        [TestCase("userCity", "Novi Sad")]
        [TestCase("brojiloId", "SE-6321W")]
        [TestCase("potroseno", "321")]
        [TestCase("potrosnjaMesec", "Januar")]

        public void GetDataByCriteria(string criteria, string value)
        {
            Historical hc = new Historical();

            Assert.DoesNotThrow(() =>
            {
                List<ModelData> list = hc.GetSelectedDataByCriteria(criteria, value).ToList();
            });
        }
        public void MockSaveDb(int userID, string username, string userAddress, string userCity, string brojiloId, decimal potroseno, string mesec)
        {
            Mock<IHistorical> mock = new Mock<IHistorical>();

            mock.Setup(p => p.WriteModelDataToDataBase(new ModelData(userID, username, userAddress, userCity, brojiloId, potroseno, mesec))).Returns(0);
        }

        [Test]
        [TestCase(1, "uname", "addrr", "city", "SE-515", 12, "Januar")]
        [TestCase(2, "uname", "addrr", "city", "SE-515", 12, "Februar")]
    }
}
