using FluentValidation;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using InstantPOS.Application.Common.Behaviours;
using AutoMapper;
using InstantPOS.Application.Interfaces.DatabaseServices;
using InstantPOS.Infrastructure.DatabaseServices;

namespace InstantPOS.Application
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient<IProductTypeDataService, ProductTypeDataServices>();
            return services;
        }
    }
}
