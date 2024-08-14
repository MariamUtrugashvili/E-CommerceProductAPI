using E_CommerceProduct.Application.Common;
using E_CommerceProduct.Application.Repositories;
using E_CommerceProduct.Application.Services;
using E_CommerceProduct.Infrastructure.Common;
using E_CommerceProduct.Infrastructure.Repositories;
using E_CommerceProduct.Infrastructure.Services;
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

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductQuantityRepository, ProductQuantityRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductQuantityService, ProductQuantityService>();
            return services;
        }
    }
}
