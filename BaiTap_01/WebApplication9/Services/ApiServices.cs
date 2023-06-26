using WebApplication8.Settings;

namespace WebApplication8.Services
{
    public class ApiServices
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public ApiServices(AppSetting appSetting,HttpClient httpClient)
        {
            _apiUrl = appSetting.ApiUrl;
            _httpClient = httpClient;
        }


    }
}
