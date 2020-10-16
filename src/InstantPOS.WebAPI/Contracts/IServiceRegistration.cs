using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstantPOS.WebAPI.Contracts
{
    public interface IServiceRegistration
    {
        void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
    }
}
