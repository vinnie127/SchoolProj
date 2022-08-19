using Newtonsoft.Json;

namespace ITHSWeb.Models.ViewModel
{
    public class ListStudentVM
    {
        
        public int id { get; set; }
    
        public string title { get; set; }
        public IEnumerable<StudentVM> student { get; set; }


    }
}
