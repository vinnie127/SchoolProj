using ITHSApi.Models.DTO.CourseDto;

namespace ITHSApi.Models.DTO.TeacherDto
{
    public class ViewTeacherCoursesDto
    {



        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

        public ICollection<ViewCourseDetailsDto> Courses { get; set; } = new List<ViewCourseDetailsDto>();





    }
}
