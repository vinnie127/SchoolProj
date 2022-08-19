using ITHSApi.Models.DTO.CourseDto;
using System.ComponentModel.DataAnnotations;

namespace ITHSApi.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }


       

    }
}
