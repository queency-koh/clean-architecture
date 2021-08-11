using CleanArchitecture.Application.TodoLists.Queries.GetTodoLists;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddTransient<IGetTodoListsQuery, GetTodoListsQuery>();

            return services;
        }
    }
}