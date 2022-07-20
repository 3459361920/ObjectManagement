using System;
using System.Collections.Generic;
using System.Text;

namespace Wathet.Common
{
    public static class DoException
    {
        public static string ToSimple(this Exception ex, string Action = "")
        {
            if (ex == null) return string.Empty;
            return string.IsNullOrEmpty(Action)
                ? new { ex.Message, ex.Source, ex.StackTrace }.ToJson()
                : new { Action, ex.Message, ex.Source, ex.StackTrace, }.ToJson();
        }
    }
}
