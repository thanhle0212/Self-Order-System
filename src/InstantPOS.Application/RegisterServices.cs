using FluentValidation;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using InstantPOS.Application.Common.Behaviours;
using AutoMapper;
using InstantPOS.Infrastructure.DatabaseServices;
using InstantPOS.Application.DatabaseServices;
using Microsoft.Extensions.Configuration;
using InstantPOS.Application.Common;
using InstantPOS.Application.DatabaseServices.Interfaces;

namespace InstantPOS.Application
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient<IProductTypeDataService, ProductTypeDataServices>();
            services.AddTransient<IDatabaseConnectionFactory>(e => {
                return new SqlConnectionFactory(configuration[Configuration.ConnectionString]);
            });
            return services;
        }
    }
}
