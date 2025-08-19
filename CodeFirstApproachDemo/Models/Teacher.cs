using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproachDemo.Models
{
    // //1 Subject---M Teachers
  ///1 Dept--M Employees
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        public string TeacherName { get; set; }

        //Foreign Key
        public int SubjectID { get; set; }

        //Navigation Property
        public Subject  Subject { get; set; }
    }

    public class Subject
    {
        [Key]
        public int SubID { get; set; }
        public string SubName { get; set; }

        //Navigation Property
        public ICollection<Teacher> Teachers { get; set; }
    }
}
