using System;
using NUnit.Framework;
using PhoneBookTestApp;
using PhoneBookTestApp.Business;

namespace PhoneBookTestAppTests
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
            Assert.IsNull(actual);
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
            Assert.AreSame(expected, actual);
        }
    }
}