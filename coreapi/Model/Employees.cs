using System.ComponentModel.DataAnnotations;

namespace coreapi.Model
{
    public class Employees
    {
        [Key]
        public Guid EMPID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }    
        public string Gender { get; set; }
        public int Salary { get; set; } 
        public string Mobile { get; set; }
    }
}
