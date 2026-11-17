namespace BlazorApp.Application.Services;

/// <summary>
/// Base service class for application services
/// </summary>
public abstract class BaseService
{
    protected readonly IServiceProvider ServiceProvider;

    protected BaseService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }
}
