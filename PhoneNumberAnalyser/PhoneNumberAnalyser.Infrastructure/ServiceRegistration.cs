using Microsoft.Extensions.DependencyInjection;
using PhoneNumberAnalyser.Application.Interfaces.IRepository;
using PhoneNumberAnalyser.Infrastructure.Data;

namespace PhoneNumberAnalyser.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDataSource, DataSource>();
            return services;
        }
    }
}
