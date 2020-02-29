using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using PhoneBookTestApp.Business.Models;

namespace PhoneBookTestApp.Data.EntityFramework
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Person> PhoneBook { get; set; }
    }
}