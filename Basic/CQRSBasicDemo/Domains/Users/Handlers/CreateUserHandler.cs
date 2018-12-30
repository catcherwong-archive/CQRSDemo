namespace CQRSBasicDemo.Domains.Users.Handlers
{
    using System.Threading.Tasks;
    using CQRSBasicDemo.Domains.Entities;
    using CQRSBasicDemo.Domains.Users.Commands;
    using CQRSBasicDemo.Infrastructure;

    public class CreateUserHandler : ICommandHandlerAsync<CreateUser>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(CreateUser command)
        {
            var user = User.CreateNew(command.UserName);
            await _userRepository.CreateAsync(user);
        }
    }
}
