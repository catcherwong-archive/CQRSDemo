namespace CQRSBasicDemo.Infrastructure
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery
    {
        TResult Retrieve(TQuery query);
    }
}
