namespace PlatformService.Extentions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContextModel();
        return services;
    }

    public static IServiceCollection AddDbContextModel(this IServiceCollection services){
        //services.AddDbContext<>;
        return services;
    }
}