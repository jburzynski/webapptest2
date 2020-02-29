using NSubstitute;
using NUnit.Framework;
using PhoneBookTestApp;
using PhoneBookTestApp.Business;
using PhoneBookTestApp.Business.Models;

namespace PhoneBookTestAppTests.Business
{
    [TestFixture]
    public class PhoneBookServiceTest
    {
        private PhoneBookService _phoneBookService;
        private IRepository<Person> _personRepository;
        
        [SetUp]
        public void SetUp()
        {
            _personRepository = Substitute.For<IRepository<Person>>();
            _phoneBookService = new PhoneBookService(_personRepository);
        }

        [Test]
        public void GetPhoneBook_PhoneBookPopulatedWithDatabaseEntries()
        {
            //arrange
            var expected = new Person { Name = "A B" };
            _personRepository.GetAll().Returns(new[] { expected });
            
            //act
            IPhoneBook phoneBook = _phoneBookService.GetPhoneBook();
            Person actual = phoneBook.FindPerson("A", "B");

            //assert
            Assert.AreSame(expected, actual);
        }
    }
}