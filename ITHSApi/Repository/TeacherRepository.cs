using Microsoft.EntityFrameworkCore;
using ITHSApi.Repository.IRepository;
using ITHSApi;
using ITHSApi.Models;

namespace ITHSApi.Repository
{
    public class TeacherRepository : ITeacherRepository
    {


        private readonly ApplicationDbContext _db;

        public TeacherRepository(ApplicationDbContext db)
        {

            _db = db;



        }


        
        public bool CreateTeacher(Teacher teacher)
        {
            _db.Teachers.Add(teacher);
            return Save();
        }


        public bool DeleteTeacher(Teacher teacher)
        {
            _db.Teachers.Remove(teacher);
            return Save();
        }


        public ICollection<Teacher> GetCourses(int teacherId)
        {
            
            return _db.Teachers.Where(c=>c.TeacherId == teacherId).Include(a=>a.Courses).ToList();


        }

        public Teacher GetTeacher(int teacherId)
        {
            return _db.Teachers.FirstOrDefault(c => c.TeacherId == teacherId);
        }

        
      

        public bool UpdateTeacher(Teacher teacher)
        {
            _db.Teachers.Update(teacher);
            return Save();
        }

        public ICollection<Teacher> GetTeachers()
        {
            return _db.Teachers.OrderBy(a => a.FirstName).ToList();
        }


        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool AddToCourse(int teacherId, int courseId)
        {

            var teacherObj = GetTeacher(teacherId);
            var CourseObj = _db.Courses.FirstOrDefault(c => c.Id == courseId);
            teacherObj.Courses.Add(CourseObj);


            return Save();


        }
    }
}
