using ITHSWeb.Repository.IRepository;
using ITHSWeb.Models;

namespace ITHSWeb.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {


        private readonly IHttpClientFactory _clientFactory;

        public CourseRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {

            _clientFactory = clientFactory;


        }

    }
}
