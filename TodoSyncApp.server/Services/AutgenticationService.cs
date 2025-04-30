using System;

namespace TodoSyncApp.Server.Services
{
    public class AuthenticationService
    {
        // Simulación de base de datos de usuarios
        private static readonly string validUsername = "user";
        private static readonly string validPassword = "password";

        public bool Authenticate(string username, string password)
        {
            return username == validUsername && password == validPassword;
        }
    }
}
