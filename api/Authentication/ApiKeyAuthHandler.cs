using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace api.Authentication
{
    public class ApiKeyAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private const string API_KEY_NAME = "X-MASTER-KEY";
        private const string MASTER_KEY = "TOKEN_FAKE"; 

        public ApiKeyAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
        ) : base(options, logger, encoder, clock) { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(API_KEY_NAME, out var apiKey))
            {
                return Task.FromResult(AuthenticateResult.Fail("Falta la API Key."));
            }

            if (apiKey != MASTER_KEY)
            {
                return Task.FromResult(AuthenticateResult.Fail("API Key inválida."));
            }

            var claims = new[] { new Claim(ClaimTypes.Name, "MasterUser") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }

    }
}
