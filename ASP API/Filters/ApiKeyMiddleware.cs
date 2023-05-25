namespace ASP_API.Filters
{
    public class ApiKeyMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var apiKey = _configuration.GetValue<string>("ApiKey");

            if (!context.Request.Headers.TryGetValue("X-Api-Key", out var key))
            {
                key = context.Request.Query.TryGetValue("x-api-key", out var value) ? value.ToString() : null;
                if (string.IsNullOrEmpty(key))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("API key is missing.");
                    return;
                }
            }

            if (!apiKey.Equals(key))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid API key.");
                return;
            }

            await _next(context);
        }
    }
}
