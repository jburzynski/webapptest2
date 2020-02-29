using System;
using NUnit.Framework;
using PhoneBookTestApp;
using PhoneBookTestApp.Business;
using PhoneBookTestApp.Business.Models;

namespace PhoneBookTestAppTests.Business
{
    [TestFixture]
    public class PhoneBookTest
    {
        private PhoneBook _phoneBook;

        [SetUp]
        public void SetUp()
        {
            _phoneBook = new PhoneBook();
        }

        [Test]
        public void AddPerson_PersonWithTheSameNameAlreadyExists_ExceptionThrown()
        {
            //arrange
            const string name = "Derissa Way";
            
            var person1 = new Person { Name = name };
            var person2 = new Person { Name = name };
            
            _phoneBook.AddPerson(person1);
            
            //act, assert
            Assert.Throws<ArgumentException>(() => { _phoneBook.AddPerson(person2); });
        }

        [Test]
        public void FindPerson_PersonNotFound_NullReturned()
        {
            //arrange
            const string firstName = "Marcus";
            const string lastName = "Unread";
            
            //act
            Person actual = _phoneBook.FindPerson(firstName, lastName);
            
            //assert
            Assert.That(actual, Is.Null);
        }
        
        [Test]
        public void AddPersonCombinedWithFindPerson_PersonAdded_PersonFound()
        {
            //arrange
            const string firstName = "Manny";
            const string lastName = "More";
            var expected = new Person { Name = firstName + " " + lastName };

            //act
            _phoneBook.AddPerson(expected);
            Person actual = _phoneBook.FindPerson(firstName, lastName);
            
            //assert
            Assert.That(expected, Is.SameAs(actual));
        }
        
        [Test]
        public void ToString_Test()
        {
            //arrange

            string expected = $"A B, C D, E F{Environment.NewLine}G H, I J, K L{Environment.NewLine}";
            
            var person1 = new Person
            {
                Name = "A B",
                PhoneNumber = "C D",
                Address = "E F"
            };
            
            var person2 = new Person
            {
                Name = "G H",
                PhoneNumber = "I J",
                Address = "K L"
            };
            
            _phoneBook.AddPerson(person1);
            _phoneBook.AddPerson(person2);
            
            //act
            string actual = _phoneBook.ToString();
            
            //assert
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}