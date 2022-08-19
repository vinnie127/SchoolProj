using ITHSApi.Models.DTO.CourseDto;
using System.ComponentModel.DataAnnotations;

namespace ITHSApi.Models
{
    public class CategoryDto
    {

        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
