using System.Collections.Generic;
using PhoneBookTestApp.Data.Models;

namespace PhoneBookTestApp.Business
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IRepository<Person> _personRepository;

        public PhoneBookService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public IPhoneBook GetPhoneBook()
        {
            IEnumerable<Person> people = _personRepository.GetAll();
            return new PhoneBook(people);
        }
    }
}