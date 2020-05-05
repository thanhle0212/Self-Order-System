using InstantPOS.Application.Interfaces.Repositories;
using InstantPOS.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace InstantPOS.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<IDatabaseConnectionFactory, SqlConnectionFactory>();
            return services;
        }
    }
}
