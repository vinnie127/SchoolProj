using System.ComponentModel.DataAnnotations;

namespace ITHSWeb.Models
{
    public class Student
    {

        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Epost { get; set; }

        public string PhoneNumber { get; set; }

        public string StreetAdress { get; set; }

      
        public ICollection<Competence> Competencies { get; set; } = new List<Competence>();

        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
