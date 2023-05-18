using Newtonsoft.Json;

namespace Shop.WebApp.Services;

public class TServices : ITServices
{
    public async Task<List<T>> GetAll<T>(string apiUrl)
    {
        var httpClient = new HttpClient(); // tạo ra để callApi
        var response = await httpClient.GetAsync(apiUrl);
        // Lấy dữ liệu Json trả về từ Api được call dạng string
        string apiData = await response.Content.ReadAsStringAsync();
        // Đọc từ string Json vừa thu được sang List<T>
        List<T> list = JsonConvert.DeserializeObject<List<T>>(apiData);
        return list;
    }
}
