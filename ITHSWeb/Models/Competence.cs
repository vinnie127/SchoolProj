using System.ComponentModel.DataAnnotations;

namespace ITHSWeb.Models
{
    public class Competence
    {

        [Key]
        public int CompetenceId { get; set; }
        [Required]
        public string CompetenceName { get; set; }

    }
}
