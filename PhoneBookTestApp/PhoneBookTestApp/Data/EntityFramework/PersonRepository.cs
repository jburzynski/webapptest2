using System.Collections.Generic;
using System.Linq;
using PhoneBookTestApp.Business.Models;

namespace PhoneBookTestApp.Data.EntityFramework
{
    /**
     * This class shows one way to operate on the database (using EntityFramework).
     * There is another implementation of the same functionality using SQLite commands in PhoneBookTestApp.Data.PersonRepository.
     * Either of the repository classes can be used as an IRepository<Person> in this application, without affecting any results.
     */
    public class PersonRepository : IRepository<Person>
    {
        public void Add(IEnumerable<Person> entities)
        {
            using (var context = new PhoneBookContext())
            {
                context.PhoneBook.AddRange(entities);
                context.SaveChanges();
            }
        }

        public IEnumerable<Person> GetAll()
        {
            IList<Person> result;
            
            using (var context = new PhoneBookContext())
            {
                result = context.PhoneBook.ToList(); // materialising the result
            }

            return result;
        }
    }
}