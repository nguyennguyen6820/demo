namespace BaiTap02.Settings
{
    public class AppSetting
    {
        public string ApiUrl { get; set; }
        public static AppSetting MapValue(IConfiguration configuration)
        {
            var apiUrl = configuration.GetValue<string>(nameof(ApiUrl));
            return new AppSetting { ApiUrl = apiUrl };
        }
    }
}
