using ITHSWeb.Models.DTO.LogIn;
using ITHSWeb.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHSWeb.Models.Repository.IRepository
{
    public interface IAccountRepository : IRepository<User>
    {

        Task<T> LoginAsync<T>(string url, LoginRequestDto ObjToCreate);
        Task<bool> RegisterAsync(string url, RegisterationRequestDto ObjToCreate);


    }
}
