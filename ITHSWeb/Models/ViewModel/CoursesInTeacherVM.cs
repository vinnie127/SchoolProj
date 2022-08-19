namespace ITHSWeb.Models.ViewModel
{
    public class CoursesInTeacherVM
    {

        public int teacherId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public IEnumerable<CourseVM> courses { get; set; }



    }
}
