using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproachDemo.Models
{
    public class Exam
    {
        [Key]
        public string ExamName { get; set; }
        public int ExamDate { get; set; }
    }
}
