using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoSyncApp.Client.Helpers
{
    public static class SessionManager
    {
        public static string LoggedInUsername { get; set; }

        public static void SaveSession()
        {
            File.WriteAllText("session.txt", LoggedInUsername);
        }

        public static bool LoadSession()
        {
            if (File.Exists("session.txt"))
            {
                LoggedInUsername = File.ReadAllText("session.txt");
                return !string.IsNullOrWhiteSpace(LoggedInUsername);
            }
            return false;
        }

        public static void ClearSession()
        {
            if (File.Exists("session.txt"))
                File.Delete("session.txt");
        }


    }


}

