using SmartHive.Providers.Contracts;
using System;

namespace SmartHive.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
