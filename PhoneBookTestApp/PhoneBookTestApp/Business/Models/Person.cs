using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBookTestApp.Business.Models
{
    [Table("PHONEBOOK")]
    public class Person
    {
        [Key]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Name}, {PhoneNumber}, {Address}";
        }
    }
}