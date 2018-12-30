namespace CQRSBasicDemo.Domains.Users
{
    using System.Threading.Tasks;
    using CQRSBasicDemo.Domains.Entities;

    public interface IUserRepository
    {
        Task CreateAsync(User user);
    }
}
