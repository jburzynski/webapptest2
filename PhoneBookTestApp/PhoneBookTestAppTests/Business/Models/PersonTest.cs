using NUnit.Framework;
using PhoneBookTestApp.Business.Models;

namespace PhoneBookTestAppTests.Business.Models
{
    [TestFixture]
    public class PersonTest
    {
        [Test]
        public void ToString_Test()
        {
            //arrange

            const string expected = "A B, C D, E F";
            
            var person = new Person
            {
                Name = "A B",
                PhoneNumber = "C D",
                Address = "E F"
            };
            
            //act
            string actual = person.ToString();
            
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}