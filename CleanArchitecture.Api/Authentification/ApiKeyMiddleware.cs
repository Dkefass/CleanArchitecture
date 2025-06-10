namespace CleanArchitecture.Api.Authentification
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

        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.TryGetValue(AuthenticationConstants.ApiKeyHeaderName,out var extratedApiKey)){
                context.Response.StatusCode = 401;

                await context.Response.WriteAsync("ApiKey introuvable");
                return;

            }

            var Apikey =  _configuration.GetValue<string>(AuthenticationConstants.ApiKeySectionName);
            if (!Apikey.Equals(extratedApiKey)) {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("ApiKey invalide");
                return;
            }
            await _next(context);
        }
    }
}
