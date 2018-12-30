namespace CQRSBasicDemo.Domains.Users.Commands
{
    using CQRSBasicDemo.Infrastructure;

    public class CreateUser : ICommand
    {
        public CreateUser(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; private set; }
    }
}
