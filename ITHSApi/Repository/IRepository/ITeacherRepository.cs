

using ITHSApi.Models;

namespace ITHSApi.Repository.IRepository
{
    public interface ITeacherRepository
    {



        ICollection<Teacher> GetCourses(int TeacherId);
        ICollection<Teacher> GetTeachers();
        Teacher GetTeacher(int teacherId);
        bool CreateTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(Teacher teacher);
        bool AddToCourse(int teacherId, int courseId);

        bool Save();


    }
}
