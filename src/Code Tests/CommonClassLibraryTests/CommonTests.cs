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

            }
        }
    }
}
