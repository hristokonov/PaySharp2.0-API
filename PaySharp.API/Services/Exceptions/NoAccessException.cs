using System;

namespace PaySharp.API.Services.Exceptions
{
    public class NoAccessException : Exception
    {
        public NoAccessException(string message) : base(message)
        {

        }
    }
}
