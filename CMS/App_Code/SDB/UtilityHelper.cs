using CMS.EventLog;
using CMS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UtilityHelper
/// </summary>
/// 


namespace Custom.SDB
{
    public class UtilityHelper
    {
        public UtilityHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void LogEvent(object message)
        {
            EventLogProvider.LogEvent(EventType.INFORMATION, "custom", "CUSTOM", eventDescription: ValidationHelper.GetString(message, string.Empty));
        }

        public static string CustomToString(object input)
        {
            return ValidationHelper.GetString(input, "-");
        }
    }
}