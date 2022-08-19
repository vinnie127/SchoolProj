using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITHSWeb.Models;

namespace ITHSWeb.Models
{
    public class Course
    {


        
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Length { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }


        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } = new Category();

        public List<Student>? Student { get; set; } = new List<Student>();
        public ICollection<Teacher>? Teacher { get; set; }


    }
}
