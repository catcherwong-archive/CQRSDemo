namespace CQRSBasicDemo.Infrastructure
{
    using System.Threading.Tasks;

    public interface ICommandSender
    {
        Task SendAsync<TCommand>(TCommand command)
            where TCommand : ICommand;
            
        void Send<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
