using System.ComponentModel.DataAnnotations;

namespace Example377
{
    public class Employee
    {
        [Key]
        public int EmpIdentity { get; set; }
        public int EmpAge { get; set; }
        public string EmpName { get; set; }
    }
}
