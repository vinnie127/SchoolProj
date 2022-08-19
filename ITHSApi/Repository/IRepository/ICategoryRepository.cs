using ITHSApi.Models;

namespace ITHSApi.Repository.IRepository
{
    public interface ICategoryRepository
    {


        ICollection<Category> GetCategories();
        ICollection<Course> GetCourses(int courseId);

        Category GetCategory(int categoryId);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);


        bool Save();




    }
}
