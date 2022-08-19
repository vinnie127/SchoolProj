using ITHSApi.Models;
using ITHSApi.Models.DTO.LogIn;

namespace ITHSApi.Repository.IRepository
{
    public interface IUserRepository
    {

        bool IsUniqueUser(string username);
        //LoginReponse är det den returnerar 
        Task<LoginResponseDTO> Login(LoginRequestDto loginRequestDTO);

        Task<User> Register(RegisterationRequestDto registerationRequestDto);


        //User Authenticate(string username, string password);
        //User Register(string username, string password);




    }
}
