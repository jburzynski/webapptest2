using PhoneBookTestApp.Business;
using PhoneBookTestApp.Data;
using PhoneBookTestApp.Data.Models;
using SimpleInjector;

namespace PhoneBookTestApp.DependencyInjection
{
    public class DiConfig
    {
        private readonly Container _container;

        public DiConfig()
        {
            _container = new Container();
            
            _container.Register<IRepository<Person>, PersonRepository>(); // for SQLite commands repository
//            _container.Register<IRepository<Person>, PhoneBookTestApp.Data.EntityFramework.PersonRepository>(); // for EntityFramework repository
            _container.Register<IPhoneBookService, PhoneBookService>();
            
            _container.Verify();
        }

        public Container GetContainer() => _container;
    }
}