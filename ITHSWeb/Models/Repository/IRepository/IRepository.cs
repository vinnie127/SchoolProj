using ITHSWeb.Models;
using ITHSWeb.Models.ViewModel;
using ITHSWeb.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHSWeb.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string url, int Id);
        Task<IEnumerable<T>> GetAllAsync(string url);
        Task<bool> CreateAsync(string url, T objToCreate);
        Task<bool> UpdateAsync(string url, T objToUpdate);
        Task<bool> DeleteAsync(string url, int Id);



        Task<IEnumerable<CoursesInTeacherVM>> CoursesInTeacher(string url, int id);
        Task<IEnumerable<CourseListVM>> GetCoursesFromStudent(string url, int id);
        Task<IEnumerable<ListStudentVM>> GetStudents(string url, int id);
    }
}
