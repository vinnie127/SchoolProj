using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ITHSApi.Models;
using ITHSApi.Repository.IRepository;
using ITHSApi;
using ITHSApi.Models;

namespace ITHSApi.Repository
{
    public class CourseRepository : ICourseRepository
    {


        private readonly ApplicationDbContext _db;
        


        public CourseRepository(ApplicationDbContext db)
        {


            _db = db;
            
        }




        public bool CreateCourse(Course courseId)
        {
            _db.Courses.Add(courseId);

            return Save();
        }

        public ICollection<Course> GetCourses()
        {
            return _db.Courses.OrderBy(a => a.Title).ToList();


            

        }

        public Course GetCourse(int courseId)
        {

            return _db.Courses.FirstOrDefault(a => a.Id == courseId);



        }


        public bool UpdateCourse(Course id)
        {
            _db.Courses.Update(id);
            return Save();
        }


        public bool DeleteCourse(Course id)
        {
            _db.Courses.Remove(id);
            return Save();
        }




        public ICollection<Course> GetStudents(int courseId)
        {

            return _db.Courses.Where(c => c.Id == courseId).Include(c => c.Student).ToList();

        }

        public ICollection<Course> GetTeachers(int courseId)
        {
            return _db.Courses.Where(c => c.Id == courseId).Include(c => c.Teacher).ToList();
        }


        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        


        //Tillkommer 2022-08-06
        public Course AddStudent(int courseId)
        {

            return _db.Courses.FirstOrDefault(a => a.Id == courseId);



        }

    }
}
