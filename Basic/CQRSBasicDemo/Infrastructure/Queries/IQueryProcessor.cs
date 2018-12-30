namespace CQRSBasicDemo.Infrastructure
{
    using System.Threading.Tasks;

    public interface IQueryProcessor
    {
        Task<TResult> ProcessAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;

        TResult Process<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}
