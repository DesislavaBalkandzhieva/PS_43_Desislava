using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string ToString(User user)
        {
            return $"Id: {user.Id}, Name: {user.Name}, Password: {user.Password}, ExpiryDate: {user.Role}";
        }

        public static User GetUser(string username, string password) 
        {
            ValidateCredentials(username, password);
            User user = new UserData().GetUser(username, password) ?? throw new Exception("Leka ti prust");
            return user;
        }

        public static void ValidateCredentials(string username, string password)
        {
            if (username == null || password == null)
            {
                throw new Exception("Leka ti prast");
            }
        }
    }
}
