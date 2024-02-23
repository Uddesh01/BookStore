using CommonLayer.Model;
using RepositoryLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        public AdminEntity Register(AdminModel newAdmin);
        public string Login(string adminEmail, string password);
    }
}
