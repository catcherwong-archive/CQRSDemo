namespace BasicDemo.Repositories
{
    using System;
    using System.Threading.Tasks;
    using BasicDemo.Models;

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

            Console.WriteLine($"CreateAsync - {user.Id}-{user.Name}");
        }

        public async Task<User> GetByIdAsync(int id)
        {
            Console.WriteLine($"GetByIdAsync - {id}");
            var user = await _context.Users.FindAsync(id);
            return user;
        }
    }
}
