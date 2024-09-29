using Microsoft.Extensions.DependencyInjection;
using ServiceApp.Application.Tasks.TaskService;

namespace ServiceApp.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
        });

        services.AddScoped<ITaskToDoService, TaskToDoService>();

        return services;
    }
}
