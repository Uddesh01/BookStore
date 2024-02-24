using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entitys;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL iadminBL;
        public AdminController(IAdminBL adminBL)
        {
            iadminBL = adminBL;
        }

        [HttpPost("RegisterAdmin")]
        public ResponceModel<AdminEntity> Register(AdminModel newAdmin)
        {
            ResponceModel<AdminEntity> responce = new ResponceModel<AdminEntity>();
            try
            {
                AdminEntity admin = iadminBL.Register(newAdmin);
                if (admin != null)
                {
                    responce.Data = admin;
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
        public ResponceModel<string> Login(string AdminEmail, string Password)
        {
            ResponceModel<string> responce = new ResponceModel<string>();

            try
            {
                string token = iadminBL.Login(AdminEmail, Password);
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

    }
}
