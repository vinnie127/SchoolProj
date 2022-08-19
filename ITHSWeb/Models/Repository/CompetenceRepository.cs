using ITHSWeb.Models;
using ITHSWeb.Repository.IRepository;

namespace ITHSWeb.Repository
{
    public class CompetenceRepository : Repository<Competence> , ICompetenceRepository
    {



        private readonly IHttpClientFactory _clientFactory;

        public CompetenceRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {

            _clientFactory = clientFactory;


        }


    }
}
