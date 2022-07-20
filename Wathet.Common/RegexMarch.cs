using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Wathet.Common
{
    public class RegexMatch
    {
        public static bool EmailMatch(string email)
        {
            return Regex.IsMatch(email, "^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
        }

        public static bool WebHookMatch(string webHook)
        {
            return Regex.IsMatch(webHook, @"^(https?|ftp|file|ws)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
        }
    }
}
