using System;

namespace SmartHive.Providers.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDate();
    }
}
