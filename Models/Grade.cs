using System.ComponentModel.DataAnnotations.Schema;

namespace StudentListning.Models
{
    [Table("Grades")]
    public class Grade
    {
        public Grade(string gradeName)
        {
            GradeName = gradeName;
            Students = new List<Student>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
