namespace CQRSBasicDemo.Data.Domains
{
    using System;
    using System.Threading.Tasks;
    using CQRSBasicDemo.Domains.Entities;
    using CQRSBasicDemo.Domains.Users;

    public class UserRepository : IUserRepository
    {
        private readonly CqrsContext _context;

        public UserRepository(CqrsContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(new User { Name = user.Name });
            await _context.SaveChangesAsync();

            Console.WriteLine($"{user.Id}-{user.Name}");
        }
    }
}
