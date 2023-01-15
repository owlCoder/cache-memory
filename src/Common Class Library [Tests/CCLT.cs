using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data;
using Common_Class_Library.Implementations;

namespace Common_Class_Library_Tests
{
    [TestFixture]
    public class CCLT
    {
        [Test]
        [TestCase ()]
        public void GetConnectionTest()
        {
            using(IDbConnection konekcija = Connection.GetConnection()) 
            { 
                konekcija.Open();

                // Konekcija je otvorena
                Assert.NotNull(konekcija);
            }
        }
    }
}
