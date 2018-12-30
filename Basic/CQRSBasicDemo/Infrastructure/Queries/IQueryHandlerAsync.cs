namespace CQRSBasicDemo.Infrastructure
{
    using System.Threading.Tasks;

    public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> RetrieveAsync(TQuery query);
    }
}
