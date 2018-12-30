namespace CQRSBasicDemo.Infrastructure
{
    using System.Collections.Generic;

    public interface IResolver
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}
