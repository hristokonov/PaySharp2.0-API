using System;

namespace PaySharp.API.Services.Exceptions
{
    public class TokenExpirationException : Exception
    {
        public TokenExpirationException(string message) : base(message)
        {

        }
    }
}
