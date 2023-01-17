using Common_Class_Library.Implementations;
using Moq;
using NUnit.Framework;
using Reader_Component;
using Reader_Component.Implementations;
using Reader_Component.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reader_Component_Test
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class RCTS
    {
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
            Assert.DoesNotThrow(() =>
            {
                List<ModelData> list = (new Reader()).GetPodaciFromHistorical(criteria, value, "NUnit").ToList();
            });
        }

        [Test]
        [TestCase("", "")]
        public void ReadAllAvailableData(string criteria, string value)
        {
            Assert.DoesNotThrow(() =>
            {
                List<ModelData> list = (new Reader()).GetPodaciFromHistorical(criteria, value, "NUnit", true).ToList();
            });
        }

        [Test]
        [TestCase("", "")]
        public void ReadAllAvailableDataNonNU(string criteria, string value)
        {
            Assert.DoesNotThrow(() =>
            {
                List<ModelData> list = (new Reader()).GetPodaciFromHistorical(criteria, value, "", false).ToList();
            });
        }

        [Test]
        [TestCase("userId", "43")]
        [TestCase("userName", "dai")]
        [TestCase("userAddress", "Alekse Sanica 4")]
        [TestCase("userCity", "NoviSad")]
        [TestCase("brojiloId", "SE-321W")]
        [TestCase("potroseno", "0")]
        [TestCase("potrosnjaMesec", "Mesec")]
        public void WrongCriteria(string criteria, string value)
        {
            List<ModelData> list = (new Reader()).GetPodaciFromHistorical(criteria, value, "NUnit").ToList();

            Assert.AreEqual(list.Count, 0);
        }

        [Test]
        [TestCase()]
        public void ReadMultiData()
        {
            bool result = false;
            Reader reader = new Reader();

            try
            {
                for (int i = 1; i <= 3; i++)
                {
                    result = (reader.GetPodaciFromHistorical("userid", "1", "", true)).Count == 0;
                }
            }
            catch
            {
                Console.WriteLine("[ERROR] CONNECTION TO SERVER FAILED");
            }

            Assert.AreEqual(true, result);
        }
    }
}
