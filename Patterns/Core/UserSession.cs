using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desingPatternsFinalProject.Patterns.Creational
{
    public class UserSession
    {

        public static int CurrentUserID { get; set; } // مهم جداً عشان ربط الطلب بالزبون
        public static string CurrentUserName { get; set; }
        public static string CurrentPhone { get; set; }
        public static string CurrentEmail { get; set; }
        public static string CurrentRole { get; set; } // Customer or Driver

        public static void ClearSession()
        {
            CurrentUserID = 0;
            CurrentUserName = null;
            CurrentPhone = null;
            CurrentEmail = null;
            CurrentRole = null;
        }
    }
}
