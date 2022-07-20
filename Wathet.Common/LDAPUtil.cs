using Novell.Directory.Ldap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wathet.Common
{
    public class LDAPUtil
    {
        //private readonly LdapSettings _ldapSettings;
        public static bool Authenticate(string strADPath, string distinguishedName, string password)
        {
            Console.WriteLine("账号规则:" + distinguishedName.Substring(0, distinguishedName.IndexOf('\\') + 1).ToLower().Trim());
            if (distinguishedName.Substring(0, distinguishedName.IndexOf('\\') + 1).ToLower().Trim() == "dc\\")
            {
                var conn = new LdapConnection();
                conn.Connect(strADPath, 389);
                try
                {
                    conn.Bind(distinguishedName, password);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("AD域登录失败：" + distinguishedName + "|" + ex.Message);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("账号规则不正确!!");
                return false;
            }
        }
    }
}
