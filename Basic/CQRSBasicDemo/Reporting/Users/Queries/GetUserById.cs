namespace CQRSBasicDemo.Reporting.Users.Queries
{
    using CQRSBasicDemo.Infrastructure;

    public class GetUserById : IQuery
    {
        public GetUserById(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}
