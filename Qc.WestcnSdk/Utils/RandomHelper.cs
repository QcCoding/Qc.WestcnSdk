using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.WestcnSdk.Utils
{
    public static class RandomHelper
    {
        public static string GenerateTimeStamp()
        {
            return GenerateTimeStampInt64().ToString();
        }

        public static long GenerateTimeStampInt64()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }
    }
}
