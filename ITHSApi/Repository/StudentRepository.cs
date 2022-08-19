using Microsoft.EntityFrameworkCore;
using ITHSApi.Repository.IRepository;
using ITHSApi;
using ITHSApi.Models;

namespace ITHSApi.Repository
{
    public class StudentRepository : IStudentRepository
    {

        private readonly ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext db)
        {
        
            
            _db = db;




        }



        public bool CreateStudent(Student student)
        {
            _db.Students.Add(student);

            return Save();
        }

        public ICollection<Student> GetStudents()
        {
            return _db.Students.OrderBy(a => a.Name).ToList();
        }
        public Student GetStudent(int studentId)
        {
            return _db.Students.FirstOrDefault(a=>a.StudentId == studentId);
        }
        
        public bool DeleteStudent(Student studentId)
        {
            _db.Students.Remove(studentId);
            return Save();


        }

        public bool UpdateStudent(Student student)
        {
            _db.Students.Update(student);
            return Save();
        }



        public bool AddCourse(int studentId, int courseId)
        {

            


            var studentObj = GetStudent(studentId);
            var CourseObj = _db.Courses.FirstOrDefault(a => a.Id == courseId);
            studentObj.Courses.Add(CourseObj);


            return Save();

        }


        public ICollection<Student> GetCourses(int studentId)
        {

            //return _db.Students.Where(c => c.StudentId == studentId).Include(c => c.Courses).ToList();

            return _db.Students.Where(c => c.StudentId == studentId).Include(a=>a.Courses).ToList();

        }


        


        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

      














    }
}
