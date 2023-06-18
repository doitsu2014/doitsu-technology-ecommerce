namespace HatDieu.ApplicationCore;

public static class Extensions
{
    public static IEnumerable<string> SplitToEmails(this string value)
    {
        return value?.Split(",;\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Distinct()
            .ToArray() ?? new string[] { };
    }
    
    public static TimeZoneInfo ToTimeZoneInfo(this string timeZoneId)
    {
        try
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return timeZone;
        }
        catch
        {
            TimeZoneInfo.TryConvertIanaIdToWindowsId(timeZoneId, out var windowsTimeZoneId);
            if (windowsTimeZoneId == null)
                throw new ArgumentException(
                    $"Time Zone IANA {timeZoneId} or WINDOWS {windowsTimeZoneId} does not exist");

            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(windowsTimeZoneId);
            return timeZone;
        }
    }
}