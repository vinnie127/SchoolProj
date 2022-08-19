using System.ComponentModel.DataAnnotations;

namespace ITHSWeb.Models.ViewModel
{
    public class StudentVM
    {


        [Key]
        public int studentId { get; set; }
        [Required]
        public string name { get; set; }

        public string lastName { get; set; }

        public string epost { get; set; }

        public string phoneNumber { get; set; }

        public string streetAdress { get; set; }


    }
}
