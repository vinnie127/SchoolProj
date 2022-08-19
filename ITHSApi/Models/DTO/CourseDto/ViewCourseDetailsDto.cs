using System.ComponentModel.DataAnnotations;


namespace ITHSApi.Models.DTO.CourseDto
{
    public class ViewCourseDetailsDto
    {


        
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Length { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }



    }
}
