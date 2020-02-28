using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        private static readonly IPhoneBook phoneBook = new PhoneBook();
        
        public static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.InitializeDatabase();
                
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

                
                // TODO: insert the new person objects into the database

            }
            finally
            {
                DatabaseUtil.CleanUp();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
