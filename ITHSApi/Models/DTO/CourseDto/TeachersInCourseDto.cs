using ITHSApi.Models.DTO.TeacherDto;
using System.ComponentModel.DataAnnotations;


namespace ITHSApi.Models.DTO.CourseDto
{
    public class TeachersInCourseDto
    {

       
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<ViewTeacherDto>? Teacher { get; set; } = new List<ViewTeacherDto>();


    }
}
