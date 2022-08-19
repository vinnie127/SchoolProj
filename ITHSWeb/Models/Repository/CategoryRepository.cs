using ITHSWeb.Models;
using ITHSWeb.Repository.IRepository;

namespace ITHSWeb.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {



        private readonly IHttpClientFactory _clientFactory;

        public CategoryRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {

            _clientFactory = clientFactory;


        }

    }
}
