using CommonLayer.Model;
using RepositoryLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IAdminBL
    {
       AdminEntity Register(AdminModel newAdmin);
        string Login(string adminEmail, string paassword);
    }
}
