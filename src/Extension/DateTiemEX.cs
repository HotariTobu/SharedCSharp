using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCSharp.Extension
{
    public static class DateTiemEX
    {
        public static long GetMilli(this DateTime time)
        {
            return time.Hour * 3600L * 1000L + time.Minute * 60L * 1000L + time.Second * 1000L + time.Millisecond;
        }
    }
}
