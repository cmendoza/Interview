using Interview.BusinessLogic.Customers.Infrastructure;
using Interview.BusinessLogic.Orders.Infrastructure;
using Interview.BusinessLogic.Products.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Interview.BusinessLogic.Common
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services)
        {
            services
                .AddSingleton<ContextFactory>()
                .AddScoped<UnitOfWork>()
                .AddTransient<CustomerRepository>()
                .AddTransient<ProductRepository>()
                .AddTransient<OrderRepository>();

            return services;
        }
    }
}
