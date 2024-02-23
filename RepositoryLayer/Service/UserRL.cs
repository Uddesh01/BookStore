using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using RepositoryLayer.JwtToke;
using System.Text;

namespace RepositoryLayer.Service
{

    public class UserRL : IUserRL
    {
        private readonly BookStoreDBContext dbContext;
        private IConfiguration configuration;

        public UserRL(BookStoreDBContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }
        UserEntity IUserRL.Register(UserModel newUser)
        {
            byte[] encriptedPassword = Encoding.UTF8.GetBytes(newUser.UserPassword);
            var userEntity = new UserEntity
            {
                FristName = newUser.FirstName,
                LastName = newUser.LastName,
                UserName = newUser.UserName,
                UserContact = newUser.UserContact,
                UserEmail = newUser.UserEmail,
                UserPassword = Convert.ToBase64String(encriptedPassword),
                AddedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return userEntity;
        }

        string IUserRL.Login(string userEmail, string password)
        {
            string encriptedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            JwtToken token = new JwtToken(configuration);
            var user = dbContext.Users.SingleOrDefault(u => u.UserEmail == userEmail && u.UserPassword == encriptedPassword);
            if (user != null)
            {
                return token.GenerateToken(user,"User");
            }
            else
            {
                throw new InvalidOperationException("User not found or password is in correct");
            }
        }

        bool IUserRL.ResetPassword(string userEmail, string oldPassword, string newPassword)
        {
            string encriptedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(oldPassword));
            UserEntity user = dbContext.Users.SingleOrDefault(u => u.UserEmail == userEmail && u.UserPassword == encriptedPassword);
            if (user != null)
            {
                string encriptedNewPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(oldPassword));
                user.UserPassword = encriptedNewPassword;
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                throw new InvalidOperationException("User not found or password is in correct");
            }
        }

        string IUserRL.ForgotPassword(string userEmail)
        {
            JwtToken token = new JwtToken(configuration);
            UserEntity user = dbContext.Users.FirstOrDefault(u => u.UserEmail == userEmail);
            if (user != null)
            {
                return token.GenerateToken(user,"role");
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }
        }
    }
}
