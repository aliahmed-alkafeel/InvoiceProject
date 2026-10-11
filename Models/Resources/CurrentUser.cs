using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CurrentUserDetails
{
    public static class CurrentUser
    {
        public static Guid UserId { get; private set; }
        public static bool IsLoggedIn
        {
            get { return UserId != Guid.Empty; }
        }

        public static void LogIn(Guid userId)
        {
            UserId = userId;
        }

        public static void LogOut()
        {
            UserId = Guid.Empty;
        }
    }
}
