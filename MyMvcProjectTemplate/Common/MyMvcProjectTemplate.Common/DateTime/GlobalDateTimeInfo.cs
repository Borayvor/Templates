namespace MyMvcProjectTemplate.Common.DateTime
{
    using System;

    public class GlobalDateTimeInfo
    {
        public static DateTime GetDateTimeUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
