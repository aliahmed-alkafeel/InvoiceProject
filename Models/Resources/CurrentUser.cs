using Models.DTOs;
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
        public static HashSet<string> Roles { get; private set; } = new HashSet<string>();
        public static bool IsLoggedIn
        {
            get { return UserId != Guid.Empty; }
        }

        public static void LogIn(Guid userId,List<string> roles)
        {
            UserId = userId;
            Roles = roles.ToHashSet();
        }

        public static void LogOut()
        {
            UserId = Guid.Empty;
            Roles.Clear();
        }

        public static bool HasRole(string role)
            {
                return Roles.Contains(role);
        }

    }
}
