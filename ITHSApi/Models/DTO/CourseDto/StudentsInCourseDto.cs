using System.ComponentModel.DataAnnotations;
using ITHSApi.Models;
using ITHSApi.Models.DTO.Student;

namespace ITHSApi.Models.DTO.CourseDto
{
    public class StudentsInCourseDto
    {

       
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<ViewStudentDto> Student { get; set; } = new List<ViewStudentDto>();

    }
}
