using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHSApi.Models
{
    public class Course
    {


        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Length { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }


        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } = new Category();

        public ICollection<Student>? Student { get; set; } = new List<Student>();
        public ICollection<Teacher>? Teacher { get; set; }




    }
}
