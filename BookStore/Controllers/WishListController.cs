using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListBL iwishListBL;

        public WishListController(IWishListBL wishListBL)
        {
            iwishListBL = wishListBL;
        }

        [HttpPost("AddToWishList")]
        [Authorize]
        public ResponceModel<bool> AddToWishList(long bookId)
        {
            ResponceModel<bool> responce = new ResponceModel<bool>();
            try
            {
                string userIdStr = User.FindFirstValue("UserId");
                long userId = Convert.ToInt32(userIdStr);
                bool wishListed = iwishListBL.AddToWishList(userId, bookId);
                if (wishListed)
                {
                    responce.Message = "Book added to wishlist successfully";
                    responce.Data = true;
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Failed to add book to wishlist";
                    responce.Data = false;
                }
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.Data = false;
                responce.IsSuccess=false;
            }
            return responce;
        }

        [HttpPost("RemoveFromWishList")]
        [Authorize]
        public ResponceModel<bool> RemoveFromWishList(long bookId)
        {
            ResponceModel<bool> responce = new ResponceModel<bool>();
            try
            {
                string userIdStr = User.FindFirstValue("UserId");
                long userId = Convert.ToInt32(userIdStr);
                bool removed = iwishListBL.RemoveFromWishList(userId, bookId);
                if (removed)
                {
                    responce.Message = "Book removed from wishlist successfully";
                    responce.Data = true;
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Failed to remove book from wishlist";
                    responce.Data = false;
                }
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.Data = false;
                responce.IsSuccess = false;
            }
            return responce;
        }

    }
}
