using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL icartBL;

        public CartController(ICartBL cartBL)
        {
            icartBL = cartBL;
        }

        [HttpPost("AddCart")]
        [Authorize]
        public ResponceModel<CartEntity> AddCart(long bookId, int quantitys)
        {
            ResponceModel<CartEntity> responce = new ResponceModel<CartEntity>();
            string userIdStr = User.FindFirstValue("UserId");
            long userId = Convert.ToInt32(userIdStr);
            try
            {
                CartEntity cart = icartBL.AddCart(bookId, quantitys, userId);
                if (cart != null)
                {
                    responce.Message = "Successfully added item in cart";
                    responce.Data = cart;
                }
                else
                {
                    responce.Message = "Unable to add item in cart";
                    responce.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        [HttpPost("RemoveCart")]
        [Authorize]
        public ResponceModel<string> RemoveCartByCartId(long CartId)
        {
            ResponceModel<string> responce = new ResponceModel<string>();
            string userIdStr = User.FindFirstValue("UserId");
            long userId = Convert.ToInt32(userIdStr);
            try
            {
                bool isRemoved = icartBL.RemoveCartByCartId(CartId, userId);
                if (isRemoved)
                {
                    responce.Message = "Successfully removed item from cart";
                }
                else
                {
                    responce.Message = "Unable to remove item from cart";
                    responce.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        [HttpGet("GetAllCart")]
        [Authorize]
        public ResponceModel<IEnumerable<CartEntity>> GetAllCartByUserID()
        {
            ResponceModel<IEnumerable< CartEntity>> responce = new ResponceModel<IEnumerable<CartEntity>>();
            string userIdStr = User.FindFirstValue("UserId");
            long userId = Convert.ToInt32(userIdStr);
            try
            {
               IEnumerable<CartEntity> carts = icartBL.GetAllCartByUserID(userId);
                if (carts != null)
                {
                    responce.Message = "Successfully added item in cart";
                    responce.Data = carts;
                }
                else
                {
                    responce.Message = "Unable to add item in cart";
                    responce.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

    }
}
