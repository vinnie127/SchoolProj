using System.ComponentModel.DataAnnotations;

namespace ITHSApi.Models
{
    public class Competence
    {

        [Key]
        public int CompetenceId { get; set; }
        [Required]
        public string CompetenceName { get; set; }

    }
}
