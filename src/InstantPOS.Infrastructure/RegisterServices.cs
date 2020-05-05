using InstantPOS.Application.Common;
using InstantPOS.Application.Interfaces.DatabaseServices;
using InstantPOS.Infrastructure.DatabaseServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace InstantPOS.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductTypeDataService, ProductTypeDataServices>();
            services.AddTransient<IDatabaseConnectionFactory>(e => {
                return new SqlConnectionFactory(configuration[Configuration.ConnectionString]);
            });
            return services;
        }
    }
}
