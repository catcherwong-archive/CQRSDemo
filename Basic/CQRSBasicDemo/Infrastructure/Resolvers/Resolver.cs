namespace CQRSBasicDemo.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;


    public class Resolver : IResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public Resolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _serviceProvider.GetServices<T>();
        }
    }
}
