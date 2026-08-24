using Microsoft.OpenApi;

namespace FitTracker.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var contactAdress = configuration.GetValue<string>("ContactUrl");

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FitTracker API",
                    Version = "v1",
                    Description = "API for FitTracker application",
                    Contact = new OpenApiContact
                    {
                        Name = "FitTracker Team",
                        Url = new Uri(contactAdress)
                    }
                });
            });

            // Add JWT authentication to Swagger

            return services;
        }
    }
}
