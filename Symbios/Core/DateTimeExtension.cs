using System;
using System.Globalization;

namespace Symbios.Core {

    public static class DateTimeExtension {

        public static string ToDateHMString(this DateTime dateTime) {
            return dateTime.ToString("yy.MM.dd HH:mm",
                CultureInfo.InvariantCulture);
        }
        
    }
}