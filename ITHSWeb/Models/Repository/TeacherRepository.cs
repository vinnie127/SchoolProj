using ITHSWeb.Models;
using ITHSWeb.Repository.IRepository;

namespace ITHSWeb.Repository
{
    public class TeacherRepository : Repository<Teacher> , ITeacherRepository
    {


        private readonly IHttpClientFactory _clientFactory;

        public TeacherRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {

            _clientFactory = clientFactory;


        }




    }
}
