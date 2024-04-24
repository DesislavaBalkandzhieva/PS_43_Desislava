using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Weclome.Others;
using Welcome.Model;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        private List<User> _users;
        private int _nextId;

        public UserData()
        {
            _users = new List<User>();
            _nextId = 0;
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);

        }

        public User GetUser(string name, string password)
        {
            return _users.FirstOrDefault(user => user.Name == name && user.Password == password);
        }

        public void AssignUserRole(string name, UserRolesEnum role)
        {
            User user = _users.FirstOrDefault(user => user.Name == name);
            if (user != null)
            { 
                user.Role = role;
            }
        }

        public void DeleteUser(User user) 
        {
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                return user.Name == name && user.Password == password;
            }
            return false;
        }

        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Name == name && x.Password == password)
                .FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            var rc = from user in _users
                     where user.Name == name && user.Password == password
                     select user.Id;
            return rc != null;
        }
    }
}
