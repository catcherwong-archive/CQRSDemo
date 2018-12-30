namespace CQRSBasicDemo.Infrastructure
{
    public interface IHandlerResolver
    {
        THandler ResolveHandler<THandler>();
    }
}
