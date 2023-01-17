using Common_Class_Library.Implementations;
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
    }
}
