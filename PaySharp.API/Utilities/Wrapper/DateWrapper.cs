using System;

namespace PaySharp.API.Utilities.Wrapper
{
    public class DateWrapper : IDateWrapper
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
