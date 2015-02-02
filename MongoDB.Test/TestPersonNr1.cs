using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDaDa.Data;

namespace MongoDB.Test
{
    [TestClass]
    public class TestPersonNr1
    {
        [TestMethod]
        private void SavePerson1()
        {
            var person = new MongoDaDa.Data.Person();
            person.SaveBasics();
            person.UpdateBasics();
            person.ReadingStuff();
            person.TidenÄrUrLed();
        }
    }
}
