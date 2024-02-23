using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using RepositoryLayer.JwtToke;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AdminRL : IAdminRL
    {
        private readonly BookStoreDBContext dbContext;
        private IConfiguration configuration;

        public AdminRL(BookStoreDBContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }
        AdminEntity IAdminRL.Register(AdminModel newAdmin)
        {
            byte[] encriptedPassword = Encoding.UTF8.GetBytes(newAdmin.AdminPassword);

            AdminEntity newAdminEntity = new AdminEntity
            {
                FristName = newAdmin.FristName,
                LastName = newAdmin.LastName,
                AdminEmail = newAdmin.AdminEmail,
                AdminPassword = Convert.ToBase64String(encriptedPassword)
            };
            dbContext.Admins.Add(newAdminEntity);
            dbContext.SaveChanges();
            return newAdminEntity;
        }
        string IAdminRL.Login(string adminEmail, string password)
        {
            string encriptedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            JwtToken token = new JwtToken(configuration);
            AdminEntity admin = dbContext.Admins.Where(a => a.AdminEmail == adminEmail && a.AdminPassword == encriptedPassword).FirstOrDefault();
            if (admin != null)
            {
                return token.GenerateToken(admin.AdminEmail,admin.AdminId, "Admin");
            }
            else
            {
                throw new InvalidOperationException("Admin not found or password is in correct");
            }
        }

    }
}
