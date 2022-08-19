using ITHSApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ITHSApi.Models.DTO.CourseDto
{
    public class UpdateCourseDto
    {



      
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Length { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }


        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } = new Category();

    }
}
