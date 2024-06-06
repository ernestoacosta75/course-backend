using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;

namespace course_backend_aop.Aspects
{
    public class CachingInterceptor(IMemoryCache cache) : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            // Generating a cache key based on the method name and arguments
            var cacheKey = $"{invocation.Method.Name}-{string.Join("-", invocation.Arguments)}";

            if (cache.TryGetValue(cacheKey, out var cachedResult))
            {
                invocation.ReturnValue = cachedResult;
                return;
            }

            // Proceed with the original method invocation
            invocation.Proceed();

            // Caching the result for 10 minutes
            cache.Set(cacheKey, invocation.ReturnValue, TimeSpan.FromMinutes(10));
        }
    }
}
