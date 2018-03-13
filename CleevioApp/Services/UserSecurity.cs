using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleevioApp.Services
{
    public static class UserSecurity
    {
        public static bool Login(string username, string password)
        {
            // TODO users authentication
            if (username.Equals("admin") && password.Equals("admin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
