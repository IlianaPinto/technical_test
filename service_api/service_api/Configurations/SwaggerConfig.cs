using Microsoft.OpenApi.Models;

namespace service_api.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "service_api", Version = "v1" });
            });

            return services;
        }
    }
}
