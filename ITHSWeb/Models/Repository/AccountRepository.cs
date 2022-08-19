using Newtonsoft.Json;
using ITHSWeb.Models.DTO.LogIn;
using ITHSWeb.Models.Repository.IRepository;
using ITHSWeb.Repository;
using System.Text;

namespace ITHSWeb.Models.Repository
{
    //public class AccountRepository : Repository<User>, IAccountRepository
    //{



    //    private readonly IHttpClientFactory _clientFactory;

    //    public AccountRepository(IHttpClientFactory clientFactory) : base(clientFactory)
    //    {

    //        _clientFactory = clientFactory;


    //    }
       
    //    public async Task<T> LoginAsync<T>(string url, LoginRequestDto ObjToCreate)
    //    {
    //        var request = new HttpRequestMessage(HttpMethod.Post, url);

    //        if (ObjToCreate != null)
    //        {
    //            request.Content = new StringContent(JsonConvert.SerializeObject(ObjToCreate), Encoding.UTF8, "application/json");


    //        }

    //        else
    //        {
    //            return new LoginRequestDto();
    //        }


    //        var client = _clientFactory.CreateClient();
    //        HttpResponseMessage response = await client.SendAsync(request);


    //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
    //        {

    //            var jsonString = await response.Content.ReadAsStringAsync();

    //            return JsonConvert.DeserializeObject<User>(jsonString);
    //        }

    //        else
    //        {
    //            return new User();
    //        }

    //    }

     

    //    public async Task<bool> RegisterAsync(string url, RegisterationRequestDto ObjToCreate)
    //    {
    //        var request = new HttpRequestMessage(HttpMethod.Post, url);

    //        if (ObjToCreate != null)
    //        {
    //            request.Content = new StringContent(JsonConvert.SerializeObject(ObjToCreate), Encoding.UTF8, "application/json");


    //        }

    //        else
    //        {
    //            return false;
    //        }


    //        var client = _clientFactory.CreateClient();
    //        HttpResponseMessage response = await client.SendAsync(request);


    //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
    //        {

    //            return true;
                
    //        }

    //        else
    //        {
    //            return false;
    //        }
    //    }

    //}
}
