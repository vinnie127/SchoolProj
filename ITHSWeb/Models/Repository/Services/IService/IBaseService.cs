namespace ITHSWeb.Models.Repository.Services.IService
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);



    }
}
