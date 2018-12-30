namespace BasicDemo.Repositories
{
    using System.Threading.Tasks;
    using BasicDemo.Models;

    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task<User> GetByIdAsync(int id);
    }
}
