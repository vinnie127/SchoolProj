using ITHSApi.Models.DTO.CourseDto;

namespace ITHSApi.Models.DTO.Student
{
    public class ShowAllStudentsDto
    {

        public int StudentId { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public ICollection<ViewCourseDetailsDto> Courses { get; set; } = new List<ViewCourseDetailsDto>();




    }
}
