using IdentityServer4.AccessTokenValidation;
using InstantPOS.WebAPI.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace InstantPOS.WebAPI.Installers
{
    internal class RegisterIdentityServerAuthentication : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            //Setup JWT Authentication Handler with IdentityServer4
            //You should register the ApiName a.k.a Audience in your AuthServer
            //More info see: http://docs.identityserver.io/en/latest/topics/apis.html

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = config["Sts:ServerUrl"];
                        options.RequireHttpsMetadata = false;
                        options.ApiName = config["ApiResource:ApiName"];
                    });
        }
    }
}
