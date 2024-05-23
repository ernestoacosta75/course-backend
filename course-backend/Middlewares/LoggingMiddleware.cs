namespace course_backend.Middlewares;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        using (var swapStream = new MemoryStream())
        {
            var originalResponse = context.Response.Body;
            context.Response.Body = swapStream;

            await _next(context);

            swapStream.Seek(0, SeekOrigin.Begin);
            string theResponse = new StreamReader(swapStream).ReadToEnd();
            swapStream.Seek(0, SeekOrigin.Begin);

            await swapStream.CopyToAsync(originalResponse);
            context.Response.Body = originalResponse;

            // Log the response
            _logger.LogInformation("Response: {Response}", theResponse);
        }
    }
}
