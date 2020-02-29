using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookTestApp.Business;
using PhoneBookTestApp.Data.Models;
using PhoneBookTestApp.DependencyInjection;
using SimpleInjector;

namespace PhoneBookTestApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.InitializeDatabase();

                Container container = new DiConfig().GetContainer();
                var phoneBookService = container.GetInstance<IPhoneBookService>();
                IPhoneBook phoneBook = phoneBookService.GetPhoneBook();
                
                /* create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
                
                var john = new Person { Name = "John Smith", PhoneNumber = "(248) 123-4567", Address = "1234 Sand Hill Dr, Royal Oak, MI" };
                var cynthia = new Person { Name = "Cynthia Smith", PhoneNumber = "(824) 128-8758", Address = "875 Main St, Ann Arbor, MI" };
                
                phoneBook.AddPerson(john);
                phoneBook.AddPerson(cynthia);

                // print the phone book out to System.out
                
                Console.Write(phoneBook);
                
                
                /* spacing */ Console.WriteLine(); Console.WriteLine();
                
                
                // find Cynthia Smith and print out just her entry

                Person cynthiaFound = phoneBook.FindPerson("Cynthia", "Smith");
                Console.Write(cynthiaFound);
                
                
                /* spacing */ Console.WriteLine(); Console.WriteLine();

                
                // insert the new person objects into the database

                var personRepository = container.GetInstance<IRepository<Person>>();
                personRepository.Add(new[] { john, cynthia });

            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
