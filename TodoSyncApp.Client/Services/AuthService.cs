using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoSyncApp.Client.Models;

namespace TodoSyncApp.Client.Services
{
    public static class AuthService
    {
        public static User CurrentUser { get; private set; }

        public static bool Login(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;

            CurrentUser = new User { Username = username };
            return true;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool IsAuthenticated => CurrentUser != null;
    }
}
