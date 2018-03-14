using System;

namespace CryptoMastery.GDAX.API.Helpers
{
    public class TimeHelper
    {
        private static readonly DateTime EpochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long GetTimeStampInSecondsSinceUnixEpoch(DateTime currentTime)
        {
            return Convert.ToInt64((currentTime.ToUniversalTime() - EpochStart).TotalSeconds);
        }

        public static DateTime GetDateTimeFromSecondsSinceUnixEpoch(long secondsSinceUnixEpoch)
        {
            return EpochStart.Date.AddSeconds(secondsSinceUnixEpoch).ToLocalTime();
        }
    }
}