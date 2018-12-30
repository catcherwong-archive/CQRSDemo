namespace CQRSBasicDemo.Reporting.Users.Handlers
{
    using CQRSBasicDemo.Infrastructure;
    using CQRSBasicDemo.Reporting.Users.Queries;
    using System.Threading.Tasks;

    public class GetUserByIdHandler : IQueryHandlerAsync<GetUserById, GetUserByIdVm>
    {
        private readonly IUserReadRepository _userRepository;

        public GetUserByIdHandler(IUserReadRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<GetUserByIdVm> RetrieveAsync(GetUserById query)
        {
            var res = await _userRepository.GetByIdAsync(query.Id);

            return new GetUserByIdVm
            {
                Id = res.Id,
                Name = res.Name
            };
        }
    }
}
