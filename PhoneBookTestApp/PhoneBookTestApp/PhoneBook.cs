using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        /**
         * Assumes that you can only have a single person with the specified name and surname.
         * In a real-life phone book you could have more than 1 person with the same name and surname,
         * but if this was the case, then it would be impossible to find (the) 'Cynthia Smith' and print her details,
         * as there could potentially be more 'Cynthia Smith's.
         */
        private readonly IDictionary<string, Person> _people = new Dictionary<string, Person>();
        
        public void AddPerson(Person person)
        {
            if (_people.ContainsKey(person.Name))
                throw new ArgumentException("A person with this name already exists in the phone book.");
            
            _people.Add(person.Name, person);
        }

        public Person FindPerson(string firstName, string lastName)
        {
            string name = firstName + " " + lastName;
            
            return _people.ContainsKey(name) ?
                _people[$"{firstName} {lastName}"]
                : null;
        }

        public override string ToString()
        {
            return _people.Aggregate("", (current, kvp) => current + (kvp.Value + Environment.NewLine));
        }
    }
}