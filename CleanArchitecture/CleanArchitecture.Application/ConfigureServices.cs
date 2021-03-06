using AutoMapper;
using CleanArchitecture.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(PerformanceBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(UnhandledExceptionBehavior<,>));

            return services;
        }
    }
}