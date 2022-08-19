using System.ComponentModel.DataAnnotations;

namespace ITHSApi.Models.DTO.Student
{
    public class UpdateStudentDto
    {


        public int StudentId { get; set; }
       
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Epost { get; set; }

        public string PhoneNumber { get; set; }

        public string StreetAdress { get; set; }






    }
}
