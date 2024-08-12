using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Infrastructure.Common;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceProduct.Infrastructure.Extensions
{
    public static class Extension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddUnitOfWork(services);
            AddRepositories(services);
            AddServices(services);
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection repositories)
        {
            return repositories;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
