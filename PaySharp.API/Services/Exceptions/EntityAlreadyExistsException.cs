﻿using System;

namespace PaySharp.API.Services.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
