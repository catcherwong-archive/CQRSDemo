namespace CQRSBasicDemo.Data.Reporting
{
    using System.Threading.Tasks;
    using CQRSBasicDemo.Domains.Entities;
    using CQRSBasicDemo.Reporting.Users;
    using Dapper;
    using Microsoft.Extensions.Configuration;

    public class UserReadRepository : BaseReadRepository, IUserReadRepository
    {
        public UserReadRepository(IConfiguration configuration)
            : base(configuration) { }

        public async Task<User> GetByIdAsync(int id)
        {
            using (var conn = GetDbConnection())
            {
                await conn.OpenAsync();
                var res = await conn.QueryFirstOrDefaultAsync<User>(@"SELECT id AS Id, name AS Name FROM t_user
                    WHERE id = @Id; ",
                    new { Id = id });
                return new User
                {
                    Id = id,
                    Name = res.Name
                };
            }
        }
    }
}
