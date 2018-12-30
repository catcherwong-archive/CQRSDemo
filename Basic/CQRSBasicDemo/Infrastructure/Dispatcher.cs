namespace CQRSBasicDemo.Infrastructure
{
    using System.Threading.Tasks;

    public class Dispatcher : IDispatcher
    {
        private readonly ICommandSender _commandSender;
        private readonly IQueryProcessor _queryProcessor;

        public Dispatcher(ICommandSender commandSender,
            IQueryProcessor queryProcessor)
        {
            _commandSender = commandSender;
            _queryProcessor = queryProcessor;
        }

        public TResult GetResult<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            return _queryProcessor.Process<TQuery, TResult>(query);
        }

        public Task<TResult> GetResultAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            return _queryProcessor.ProcessAsync<TQuery, TResult>(query);
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            _commandSender.Send(command);
        }

        public Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            return _commandSender.SendAsync(command);
        }
    }
}
