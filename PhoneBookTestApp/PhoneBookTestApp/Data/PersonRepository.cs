using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace PhoneBookTestApp.Data
{
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