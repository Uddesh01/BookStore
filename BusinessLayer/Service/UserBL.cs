using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL iuserRL;

        public UserBL(IUserRL userRL)
        {
            iuserRL = userRL;
        }
        UserEntity IUserBL.Register(UserModel newUser)
        {
            ValidateEmail(newUser.UserEmail);
            ValidatePassword(newUser.UserPassword);
            return iuserRL.Register(newUser);
        }

        string IUserBL.Login(string userEmail, string password)
        {
            return iuserRL.Login(userEmail, password);
        }

        bool IUserBL.ResetPassword(string userEmail,string oldPassword, string newPassword)
        {
            ValidatePassword(newPassword);
            return iuserRL.ResetPassword(userEmail,oldPassword, newPassword);
        }

        string IUserBL.ForgotPassword(string userEmail)
        {
            return iuserRL.ForgotPassword(userEmail);
        }
        private void ValidateEmail(string email)
        {
            string regexPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (!Regex.IsMatch(email, regexPattern))
            {
                throw new ArgumentException("Invalid email format");
            }
        }
        private void ValidatePassword(string password)
        {
            string regexPattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$";
            if (!Regex.IsMatch(password, regexPattern))
            {
                throw new ArgumentException("Invalid password format");
            }
        }
    }
}
