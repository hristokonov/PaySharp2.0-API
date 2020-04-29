using System;

namespace PaySharp.API.Services.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {

        }
    }
}
