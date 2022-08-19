using ITHSWeb.Models.DTO.LogIn;

namespace ITHSWeb.Models.Repository.Services.IService
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDto objToCreate);
        Task<T> RegisterAsync<T>(RegisterationRequestDto objToCreate);


    }
}
