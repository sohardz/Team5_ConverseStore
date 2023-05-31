namespace Shop.WebApp.Services
{
    public interface ITServices
    {
        Task<List<T>> GetAll<T>(string apiUrl);
    }
}
