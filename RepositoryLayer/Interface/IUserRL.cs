﻿using CommonLayer.Model;
using RepositoryLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        UserEntity Register(UserModel newUser);
        string Login(string userEmail, string password);
        bool ResetPassword(string userEmail, string oldPassword, string newPassword);
        string ForgotPassword(string userEmail);
    }
}
