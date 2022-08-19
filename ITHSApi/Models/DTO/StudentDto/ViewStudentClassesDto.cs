using ITHSApi.Models;

namespace ITHSApi.Models.DTO
{
    public class ViewStudentClassesDto
    {

     
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
