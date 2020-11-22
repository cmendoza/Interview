using Interview.BusinessLogic.Customers.Infrastructure;
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
                .AddTransient<CustomerRepository>();

            return services;
        }
    }
}
