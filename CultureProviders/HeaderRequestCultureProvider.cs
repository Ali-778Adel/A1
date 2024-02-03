using A1.Constants;
using Microsoft.AspNetCore.Localization;

namespace A1.CultureProviders
{
    public class HeaderRequestCultureProvider : IRequestCultureProvider
    {
        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var headers = httpContext.Request.Headers;
            if (headers.ContainsKey("lang") && SupportedCultures.All.Any(x => x.Name.Equals(headers["lang"].ToString())))
            {
                return Task.FromResult(new ProviderCultureResult(headers["lang"].ToString()));
            }
            else
            {
                return Task.FromResult(new ProviderCultureResult(SupportedCultures.Arabic.Name));
            }
        }
    }
}