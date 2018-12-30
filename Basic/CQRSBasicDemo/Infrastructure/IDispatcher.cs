namespace CQRSBasicDemo.Infrastructure
{
    using System.Threading.Tasks;

    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command)
            where TCommand : ICommand;

        void Send<TCommand>(TCommand command)
            where TCommand : ICommand;

        TResult GetResult<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;

        Task<TResult> GetResultAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}
