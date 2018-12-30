namespace CQRSBasicDemo.Infrastructure
{
    using System;
    using System.Threading.Tasks;

    public class CommandSender : ICommandSender
    {
        private readonly IHandlerResolver _handlerResolver;

        public CommandSender(IHandlerResolver handlerResolver)
        {
            this._handlerResolver = handlerResolver;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handler = _handlerResolver.ResolveHandler<ICommandHandler<TCommand>>();

            handler.Handle(command);
        }

        public Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handler = _handlerResolver.ResolveHandler<ICommandHandlerAsync<TCommand>>();

            return handler.HandleAsync(command);
        }
    }
}
