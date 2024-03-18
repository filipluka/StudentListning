using System.ComponentModel.DataAnnotations.Schema;

namespace StudentListning.Models
{
    [Table("Courses")]
    public class Course
    {

        public Course(string courseName, string courseCredits)
        {
            CourseName = courseName;
            CourseCredits = courseCredits;
            Students = new List<Student>();
        }

        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public string CourseCredits { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}
