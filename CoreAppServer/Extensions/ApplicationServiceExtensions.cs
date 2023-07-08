using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IPropertiesService, PropertiesService>();
            services.AddDbContext<DataContext>(options => 
            {
                options.UseNpgsql(config.GetConnectionString("Default"));
            });

            return services;
        }
    }
}