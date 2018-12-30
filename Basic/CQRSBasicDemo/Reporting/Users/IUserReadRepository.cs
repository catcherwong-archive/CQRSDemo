namespace CQRSBasicDemo.Reporting.Users
{
    using CQRSBasicDemo.Domains.Entities;
    using System.Threading.Tasks;

    public interface IUserReadRepository
    {
        Task<User> GetByIdAsync(int id);
    }
}
