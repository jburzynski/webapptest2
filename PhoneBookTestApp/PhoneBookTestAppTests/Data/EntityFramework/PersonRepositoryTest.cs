using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PhoneBookTestApp;
using PhoneBookTestApp.Business.Models;
using PhoneBookTestApp.Data.EntityFramework;

namespace PhoneBookTestAppTests.Data.EntityFramework
{
    /// <summary>
    /// Integration test
    /// </summary>
    public class PersonRepositoryTest
    {
        
        
        /**
         *
         *
         *
         * This is an integration test suite
         *
         *
         * 
         */
        
        private PersonRepository _personRepository;
        
        [SetUp]
        public void SetUp()
        {
            DatabaseUtil.InitializeDatabase();
            
            _personRepository = new PersonRepository();
        }

        [TearDown]
        public void TearDown()
        {
            DatabaseUtil.CleanUp();
        }

        [Test]
        public void GetAll_ThereAreEntriesInTheDb_AllDbEntriesAreReturned()
        {
            //arrange
            
            var expectedPerson1 = new Person
            {
                Name = "Chris Johnson",
                PhoneNumber = "(321) 231-7876",
                Address = "452 Freeman Drive, Algonac, MI"
            };
            
            var expectedPerson2 = new Person
            {
                Name = "Dave Williams",
                PhoneNumber = "(231) 502-1236",
                Address = "285 Huron St, Port Austin, MI"
            };
            
            //act
            IEnumerable<Person> people = _personRepository.GetAll();
            
            //assert
            Assert.That(people.Any(x => PersonDetailsEqual(x, expectedPerson1)));
            Assert.That(people.Any(x => PersonDetailsEqual(x, expectedPerson2)));
        }
        
        [Test]
        public void AddCombinedWithGetAll_EntitiesAddedToDb_TheAddedEntitiesShouldBeReturned()
        {
            //arrange
            
            var expectedPerson1 = new Person
            {
                Name = "A B",
                PhoneNumber = "C D",
                Address = "E F"
            };
            
            var expectedPerson2 = new Person
            {
                Name = "G H",
                PhoneNumber = "I J",
                Address = "K L"
            };
            
            _personRepository.Add(new[] { expectedPerson1, expectedPerson2 });
            
            //act
            IEnumerable<Person> people = _personRepository.GetAll();
            
            //assert
            Assert.That(people.Any(x => PersonDetailsEqual(x, expectedPerson1)));
            Assert.That(people.Any(x => PersonDetailsEqual(x, expectedPerson2)));
        }

        private bool PersonDetailsEqual(Person person1, Person person2)
        {
            return person1.Name == person2.Name &&
                   person1.PhoneNumber == person2.PhoneNumber &&
                   person1.Address == person2.Address;
        }
    }
}