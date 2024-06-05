using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace course_backend_aop.Aspects
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }
        public void Intercept(IInvocation invocation)
        {
            try
            {
                _logger.LogInformation($"Calling method: {invocation.Method.Name}");
                invocation.Proceed();
                _logger.LogInformation($"Method: {invocation.Method.Name} completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Method: {invocation.Method.Name} threw an exception: {ex}");
                throw;
            }
        }
    }
}
