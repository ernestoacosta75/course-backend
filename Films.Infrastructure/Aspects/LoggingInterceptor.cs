using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace Films.Infrastructure.Aspects
{
    public class LoggingInterceptor(ILogger<LoggingInterceptor> logger) : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                logger.LogInformation("Calling method: {MethodName}", invocation.Method.Name);
                invocation.Proceed();
                logger.LogInformation("Method: {MethodName} completed successfully.", invocation.Method.Name);
            }
            catch (Exception ex)
            {
                logger.LogError("Method: {MethodName} threw an exception: {Ex}", invocation.Method.Name, ex);
                throw;
            }
        }
    }
}
