using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDaDa.Data;

namespace MongoDB.Test
{
    [TestClass]
    public class TestPersonNr1
    {

   

        [TestMethod]
        public void SavePerson()
        {
            var person = new MongoDaDa.Data.Person();
            person.SaveBasics();
        }
 
        [TestMethod]
        public void UpdatePerson()
        {
            var person = new MongoDaDa.Data.Person();
            person.UpdateBasics();

        }

        [TestMethod]
        public void ReadStuff()
        {
            var person = new MongoDaDa.Data.Person();
            person.ReadingStuff();

        }
        [TestMethod]
        public void LinqStuff()
        {
            var person = new MongoDaDa.Data.Person();
            person.LiteLinqGrejs();

        }

    }
}
