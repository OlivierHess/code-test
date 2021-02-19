using CodeTest.Domain.Areas.Products.Interfaces;
using CodeTest.SqlDataAccess.Areas.Products;
using Microsoft.Extensions.DependencyInjection;

namespace CodeTest.SqlDataAccess.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}