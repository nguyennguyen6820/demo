using Bai3.Db;
using Bai3.Setting;
using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Bai3.Extensions
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddOracleDbContext(configuration);
            services.AddKafkaProducer(configuration);
            return services;
        }

        public static IServiceCollection AddOracleDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Bai3DbContext>(options =>
            {
                options.UseOracle(configuration.GetConnectionString("Bai3"));
            });
            return services;
        }
        public static IServiceCollection AddKafkaProducer(this IServiceCollection services, IConfiguration configuration)
        {
            KafkaSetting kafkaSetting = configuration.GetSection("KafkaSetting").Get<KafkaSetting>();

            services.AddSingleton(sp =>
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = kafkaSetting.HostPort,
                    ClientId = kafkaSetting.ClientId,
                    BrokerAddressFamily = BrokerAddressFamily.V4,
                };
                return new ProducerBuilder<string, string>(config).Build();
            });
            return services;

        }
    }
}
