using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace Films.Infrastructure.Aspects
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void Intercept(IInvocation invocation)
        {
            try
            {
                _logger.LogInformation("Calling method: {MethodName}", invocation.Method.Name);
                invocation.Proceed();
                _logger.LogInformation("Method: {MethodName} completed successfully.", invocation.Method.Name);
            }
            catch (Exception ex)
            {
                _logger.LogError("Method: {MethodName} threw an exception: {Ex}", invocation.Method.Name, ex);
                throw;
            }
        }
    }
}
