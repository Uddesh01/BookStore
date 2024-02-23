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
    public class AdminBL : IAdminBL
    {
        public readonly IAdminRL iadminRL;
        public AdminBL(IAdminRL adminRL)
        {
            iadminRL = adminRL;
        }
        AdminEntity IAdminBL.Register(AdminModel newAdmin)
        {
            ValidateEmail(newAdmin.AdminEmail);
            ValidatePassword(newAdmin.AdminPassword);
           return iadminRL.Register(newAdmin);
        }
        string IAdminBL.Login(string adminEmail, string paassword)
        {
            return iadminRL.Login(adminEmail, paassword);
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
