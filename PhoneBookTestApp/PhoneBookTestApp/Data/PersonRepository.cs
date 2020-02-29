using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using PhoneBookTestApp.Data.Models;

namespace PhoneBookTestApp.Data
{
    /**
     * This class shows one way to operate on the database (using SQLite commands).
     * There is another implementation of the same functionality using EntityFramework in PhoneBookTestApp.Data.EntityFramework.PersonRepository.
     * Either of the repository classes can be used as an IRepository<Person> in this application, without affecting any results.
     */
    public class PersonRepository : IRepository<Person>
    {
        public void Add(IEnumerable<Person> entities)
        {
            using (SQLiteConnection dbConnection = DatabaseUtil.GetConnection())
            {
                var command = new SQLiteCommand(dbConnection);
                command.CommandText =
                    $"INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES(@name, @phoneNumber, @address)";

                using (SQLiteTransaction transaction = dbConnection.BeginTransaction())
                {
                    foreach (Person person in entities)
                    {
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("@name", person.Name);
                        command.Parameters.AddWithValue("@phoneNumber", person.PhoneNumber);
                        command.Parameters.AddWithValue("@address", person.Address);
                        
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        public IEnumerable<Person> GetAll()
        {
            var result = new List<Person>();
            
            using (SQLiteConnection dbConnection = DatabaseUtil.GetConnection())
            {
                var command = new SQLiteCommand(dbConnection);
                command.CommandText = "SELECT * FROM PHONEBOOK";

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Person
                    {
                        Name = Convert.ToString(reader["NAME"]),
                        PhoneNumber = Convert.ToString(reader["PHONENUMBER"]),
                        Address = Convert.ToString(reader["ADDRESS"]),
                    });
                }
            }

            return result;
        }
    }
}