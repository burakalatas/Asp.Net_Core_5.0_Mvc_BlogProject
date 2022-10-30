using System.ComponentModel.DataAnnotations;

namespace BlogApi.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
