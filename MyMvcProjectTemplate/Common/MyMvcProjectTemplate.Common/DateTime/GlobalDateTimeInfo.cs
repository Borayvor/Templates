namespace MyMvcProjectTemplate.Common.DateTime
{
    using System;

    public class GlobalDateTimeInfo
    {
        public static DateTime GetDateTimeNow()
        {
            return DateTime.UtcNow;
        }
    }
}
