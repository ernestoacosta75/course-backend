using Microsoft.AspNetCore.Mvc.Filters;

namespace course_backend.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public CustomActionFilter(ILogger<CustomActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Before executing the action");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("After executing the action");
        }
    }
}
