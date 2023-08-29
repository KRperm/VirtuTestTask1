using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Record
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
    }
}
