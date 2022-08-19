using ITHSWeb.Models.DTO.LogIn;
using ITHSWeb.Models.Repository.Services.IService;

namespace ITHSWeb.Models.Repository.Services
{
    public class AuthService : BaseService, IAuthService
    {


        private readonly IHttpClientFactory _clientFactory;
        private string LogUrl;





        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            LogUrl = configuration.GetValue<string>("ServiceUrls:SchoolAPI");

        }

        public Task<T> LoginAsync<T>(LoginRequestDto obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SDApi.ApiType.POST,
                Data = obj,
                Url = LogUrl + "/api/Users/Login"
            });
        }

        public Task<T> RegisterAsync<T>(RegisterationRequestDto obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SDApi.ApiType.POST,
                Data = obj,
                Url = LogUrl + "/api/Users/register"
            });
        }


    }
}
