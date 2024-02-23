using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entitys;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL iuserBL;
        public UserController(IUserBL iuserBL)
        {
            this.iuserBL = iuserBL;
        }

        [HttpPost("Register")]
        public ResponceModel<UserEntity> Register(UserModel newUser)
        {
            ResponceModel<UserEntity> responce = new ResponceModel<UserEntity>();
            try
            {
                UserEntity userEntity = iuserBL.Register(newUser);
                if (userEntity != null)
                {
                    responce.Data = userEntity;
                    responce.Message = "Registration successfull!!";
                }
                else
                {
                    responce.Message = "Registration Unsuccessfull!!";
                    responce.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.IsSuccess = false;
            }
            return responce;
        }

        [HttpPost("Login")]

        public ResponceModel<string> Login(string UserEmail, string Password)
        {
            ResponceModel<string> responce = new ResponceModel<string>();

            try
            {
                string token = iuserBL.Login(UserEmail, Password);
                if (token != null)
                {
                    responce.Data = token;
                    responce.Message = "Login successful";
                }
                else
                {
                    responce.Message = "Login Unsuccessfull!!";
                    responce.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.IsSuccess = false;
            }
            return responce;
        }

        [HttpPost("ResetPassword")]
        public ResponceModel<string> ResetPassword(string UserEmail, string OldPassword, string NewPassword)
        {
            ResponceModel<string> responce = new ResponceModel<string>();
            try
            {
                bool isSuccess = iuserBL.ResetPassword(UserEmail, OldPassword, NewPassword);
                if (isSuccess)
                {
                    responce.Message = "Password reset successfully!!";
                }
                else
                {
                    responce.Message = "Password is not reset successfully!!";
                    responce.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.IsSuccess = false;
            }
            return responce;
        }

        [HttpPost("ForgotPassword")]
        public ResponceModel<string> ForgotPassword(string UserEmail)
        {
            ResponceModel<string> responce = new ResponceModel<string>();
            try
            {
                string token = iuserBL.ForgotPassword(UserEmail);
                if (token != null)
                {
                    responce.Message = "Password reset successfully!!";
                    responce.Data = token;
                }
                else
                {
                    responce.Message = "Password is not reset successfully!!";
                    responce.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.IsSuccess = false;
            }
            return responce;
        }
    }
}