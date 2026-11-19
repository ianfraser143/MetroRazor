using LiteBus;

namespace BlazorApp.Api.Bus
{
    public class SimpleLiteBus : ILiteBus
    {
        private readonly IServiceProvider _serviceProvider;
        public SimpleLiteBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query)
        {
            // Resolve the appropriate handler for the query type
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResponse));
            var handler = (dynamic)_serviceProvider.GetRequiredService(handlerType);
            return await handler.HandleAsync((dynamic)query);
        }

        public async Task SendAsync(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            var handler = (dynamic)_serviceProvider.GetRequiredService(handlerType);
            await handler.HandleAsync((dynamic)command);
        }
    }
}

