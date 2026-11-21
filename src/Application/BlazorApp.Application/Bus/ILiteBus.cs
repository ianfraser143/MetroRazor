namespace LiteBus
{
    using System.Threading.Tasks;

    public interface ILiteBus
    {
        Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query);
        Task SendAsync(ICommand command);
    }

    public interface IQuery<TResponse> { }
    public interface ICommand { }
}

