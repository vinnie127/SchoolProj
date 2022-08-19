using System.ComponentModel.DataAnnotations;

namespace ITHSApi.Models
{
    public class Teacher
    {

        [Key]
        public int TeacherId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string StreetAdress { get; set; }


        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
