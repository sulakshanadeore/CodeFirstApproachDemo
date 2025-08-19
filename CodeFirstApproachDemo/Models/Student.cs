using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproachDemo.Models
{
    public class Student
    {
        [Key]
        public int RollNo { get; set; }
        public string StudName { get; set; }
        public DateTime BirthDate { get; set; }

        public string City { get; set; }
    }

   
}
