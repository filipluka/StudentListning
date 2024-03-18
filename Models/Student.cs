using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentListning.Models
{
    [Table("Students")]
    public class Student
    {

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [Key]
        public int StudentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GradeID { get; set; }
        public virtual Grade? Grade { get; set; }

        public int UniversityID { get; set; }
        public virtual University? University { get; set; }

        public int CourseID { get; set; }
        public virtual Course? Course { get; set; }

        public virtual Address? Address { get; set; }
    }
}
