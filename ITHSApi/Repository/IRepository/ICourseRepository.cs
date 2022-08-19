using ITHSApi.Models;

namespace ITHSApi.Repository.IRepository
{
    public interface ICourseRepository
    {


        ICollection<Course> GetCourses();
        ICollection<Course> GetStudents(int courseId);
        ICollection<Course> GetTeachers(int courseId);
      
        Course GetCourse(int courseId);
        bool CreateCourse(Course courseId);
        bool UpdateCourse(Course courseId);
        bool DeleteCourse(Course courseId);
        

        bool Save();








    }
}
