
using Microsoft.Extensions.DependencyInjection;
using InstantPOS.Infrastructure.DatabaseServices;
using Microsoft.Extensions.Configuration;
using InstantPOS.Application.DatabaseServices.Interfaces;
using InstantPOS.Application.Common;

namespace InstantPOS.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IProductTypeDataService, ProductTypeDataServices>();
            services.AddTransient<IProductDataService, ProductDataServices>();
            services.AddTransient<IDatabaseConnectionFactory>(e => {
                return new SqlConnectionFactory(configuration[Configuration.ConnectionString]);
            });
            return services;
        }
    }
}
