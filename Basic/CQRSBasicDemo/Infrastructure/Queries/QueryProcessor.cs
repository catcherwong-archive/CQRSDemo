namespace CQRSBasicDemo.Infrastructure
{
    using System;
    using System.Threading.Tasks;

    public class QueryProcessor : IQueryProcessor
    {
        private readonly IHandlerResolver _handlerResolver;

        public QueryProcessor(IHandlerResolver handlerResolver)
        {
            _handlerResolver = handlerResolver;
        }

        public Task<TResult> ProcessAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var handler = _handlerResolver.ResolveHandler<IQueryHandlerAsync<TQuery, TResult>>();

            return handler.RetrieveAsync(query);
        }

        public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var handler = _handlerResolver.ResolveHandler<IQueryHandler<TQuery, TResult>>();

            return handler.Retrieve(query);
        }
    }
}
