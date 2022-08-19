using ITHSWeb.Models;
using ITHSWeb.Repository.IRepository;

namespace ITHSWeb.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {



        private readonly IHttpClientFactory _clientFactory;

        public StudentRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {

            _clientFactory = clientFactory;


        }


    }
}
