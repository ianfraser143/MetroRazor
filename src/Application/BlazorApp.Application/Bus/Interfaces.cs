namespace LiteBus
{
    // IQuery<TResponse> and ICommand are defined in ILiteBus.cs; duplicate definitions removed.


    public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
        System.Threading.Tasks.Task<TResponse> HandleAsync(TQuery query);
    }

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        System.Threading.Tasks.Task HandleAsync(TCommand command);
    }
}

