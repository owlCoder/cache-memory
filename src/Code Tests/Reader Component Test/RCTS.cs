using Common_Class_Library.Implementations;
using Moq;
using NUnit.Framework;
using Reader_Component;
using Reader_Component.Implementations;

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

        public void WrongCriteria(string criteria, string value)
        {
            
        }
    }
}
