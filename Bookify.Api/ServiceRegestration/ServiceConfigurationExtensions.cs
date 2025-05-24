using Bookify.Application;
using Bookify.Infrastructure;

namespace Bookify.Api.ServiceRegestration;

public static class ServiceConfigurationExtensions
{
    public static void RegisterAllServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register MediatR services
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
        services.AddApplication();
        services.AddInfrastructure(configuration); 
    }
}
