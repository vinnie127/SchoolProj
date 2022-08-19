using Microsoft.EntityFrameworkCore;
using ITHSApi.Models;
using ITHSApi.Repository.IRepository;

namespace ITHSApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {


        private readonly ApplicationDbContext _db;



        public CategoryRepository(ApplicationDbContext db)
        {


            _db = db;

        }

        public bool CreateCategory(Category category)
        {
            _db.Categories.Add(category);

            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _db.Categories.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _db.Categories.OrderBy(a => a.Name).ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _db.Categories.FirstOrDefault(a => a.CategoryId == categoryId);
        }

        public ICollection<Course> GetCourses(int courseId)
        {
            return _db.Courses.Where(c=>c.Id == courseId).Include(c=>c.Category).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _db.Categories.Update(category);
            return Save();
        }
    }
}
