using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Wathet.Common
{
    public static class DoSession
    {

        #region //Set
        public static bool SessionSet(this Microsoft.AspNetCore.Http.HttpContext http, string Name, object strValue)
        {
            Name = Name.ToLower();
            if (http.Session != null)
            {
                try
                {
                    http.Session.SetString(Name, strValue.ToJson());
                }
                catch (Exception ex) { Console.WriteLine(ex); return false; }
            }
            return true;
        }
        #endregion

        #region //Get

        public static string SessionGet(this Microsoft.AspNetCore.Http.HttpContext http, string Name)
        {
            Name = Name.ToLower();
            if (http.Session != null && http.Session.Keys.Contains(Name))
            {
                try
                {
                    return http.Session.GetString(Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
            return null;
        }

        public static TT SessionGet<TT>(this Microsoft.AspNetCore.Http.HttpContext http, string Name) where TT : class
        {
            Name = Name.ToLower();
            if (http.Session != null && http.Session.Keys.Contains(Name))
            {
                try
                {
                    var str = http.Session.GetString(Name);
                    return string.IsNullOrEmpty(str) ? null : str.ToObjectFromJson<TT>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
            return null;
        }
        #endregion

        #region //Remove
        public static void SessionRemove(this Microsoft.AspNetCore.Http.HttpContext http, string Name)
        {
            Name = Name.ToLower();
            if (http.Session != null && http.Session.Keys.Contains(Name))
            {
                try
                {
                    http.Session.Remove(Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        } 
        #endregion

    }
}
