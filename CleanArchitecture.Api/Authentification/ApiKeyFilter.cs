using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.Api.Authentification
{
    public class ApiKeyFilter : Attribute, IAuthorizationFilter
    {
        private readonly IConfiguration _configuration; 
        public ApiKeyFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnAuthorization( AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(AuthenticationConstants.ApiKeyHeaderName, out var extratedApiKey))
            {
                context.HttpContext.Response.StatusCode = 401;

                context.Result=new UnauthorizedObjectResult("ApiKey introuvable");
                return;

            }

            var Apikey = _configuration.GetValue<string>(AuthenticationConstants.ApiKeySectionName);
            if (!Apikey.Equals(extratedApiKey))
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new UnauthorizedObjectResult("ApiKey invalide");
                return;
            }
            
        }
    }
}
