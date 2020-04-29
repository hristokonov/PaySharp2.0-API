using Microsoft.Extensions.Configuration;
using PaySharp.API.Services.Contracts;
using PaySharp.API.Services.Exceptions;
using System;
using System.Linq;

namespace PaySharp.API.Services.Identity
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly ITokenManager tokenManager;
        private readonly IConfiguration config;

        public AuthorizationManager(ITokenManager tokenManager, IConfiguration config)
        {
            this.tokenManager = tokenManager;
            this.config = config;
        }

        public void CheckIfLogged(string tokenValue)
        {
            var tokenCheckResult = tokenManager.GetPrincipal(tokenValue);

            if (tokenCheckResult == null)
            {
                throw new TokenExpirationException(config.GetSection("GlobalConstants:NOT_LOGGED").Value);
            }
        }

        public void CheckForRole(string tokenValue, string roleToCheckFor)
        {
            if (tokenValue == null)
            {
                throw new NoAccessException(config.GetSection("GlobalConstants:NOT_AUTHORIZED").Value);
            }

            var userClaimPrinciple = tokenManager.GetPrincipal(tokenValue);

            var userRole = userClaimPrinciple.Claims.Where(c => c.Type == "userRole").First().Value;

            if (userRole != roleToCheckFor)
            {
                throw new NoAccessException(config.GetSection("GlobalConstants:NOT_AUTHORIZED").Value);
            }
        }

        public long GetLoggedUserId(string tokenValue)
        {
            var userClaimPrinciple = tokenManager.GetPrincipal(tokenValue);

            if (userClaimPrinciple == null)
            {
                throw new NoAccessException(config.GetSection("GlobalConstants:NOT_LOGGED").Value);
            }

            var isIdValid = Int64.TryParse(userClaimPrinciple
                                            .Claims
                                            .Where(c => c.Type == "userId")
                                            .First()
                                            .Value,
                                            out var userId);

            if (isIdValid)
            {
                return userId;
            }
            else
            {
                throw new NoAccessException(config.GetSection("GlobalConstants:NOT_VALID_USER").Value);

            }
        }
    }
}
