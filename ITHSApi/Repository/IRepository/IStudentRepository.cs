using ITHSApi.Models;

namespace ITHSApi.Repository.IRepository
{
    public interface IStudentRepository
    {

        ICollection<Student> GetCourses(int StudentId);
        ICollection<Student> GetStudents();
        Student GetStudent(int studentId);
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        bool AddCourse(int studentId, int courseId);

        bool Save();







    }
}
