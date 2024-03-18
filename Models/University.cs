using System.ComponentModel.DataAnnotations.Schema;

namespace StudentListning.Models
{
    [Table("Universities")]
    public class University
    {
        public University(string universityName, string universityCity)
        {
            UniversityName = universityName;
            UniversityCity = universityCity;
            Students = new List<Student>();
        }
       
        public int UniversityID { get; set; }

        public string UniversityName { get; set; }

        public string UniversityCity { get; set; }

        public virtual ICollection<Student> Students { get; set; }


    }
}
