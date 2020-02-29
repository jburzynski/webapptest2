using PhoneBookTestApp.Data.Models;

namespace PhoneBookTestApp.Business
{
    public interface IPhoneBook
    {
        Person FindPerson(string firstName, string lastName);
        void AddPerson(Person person);
    }
}