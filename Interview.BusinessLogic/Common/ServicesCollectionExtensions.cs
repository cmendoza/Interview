using Interview.BusinessLogic.Customers.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Interview.BusinessLogic.Common
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services)
        {
            services
                .AddScoped<OrdersContext>()
                .AddSingleton<CustomerRepository>();

            return services;
        }
    }
}
