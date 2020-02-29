using PhoneBookTestApp.Business;
using PhoneBookTestApp.Business.Models;
using PhoneBookTestApp.Data;

namespace PhoneBookTestApp.DependencyInjection
{
    /**
     * This is a simulation of a dependency injection framework.
     * This functionality can be easily replaced with an actual DI framework, but to keep the solution simple, this class has been created instead.
     */
    public class Container : IContainer
    {
        public T Get<T>() where T : class
        {
            if (typeof(T) == typeof(IPhoneBookService))
                return (T) (IPhoneBookService) new PhoneBookService(Get<IRepository<Person>>());
            
            if (typeof(T) == typeof(IRepository<Person>))
                return (T) (IRepository<Person>) new PersonRepository(); // this for the SQLite commands repository
//                return (T) (IRepository<Person>) new PhoneBookTestApp.Data.EntityFramework.PersonRepository(); // this for the EntityFramework repository

            return null;
        }
    }
}