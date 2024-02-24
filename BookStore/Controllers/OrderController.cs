//using BusinessLayer.Interface;
//using CommonLayer.Model;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using RepositoryLayer.Entitys;
//using System.Security.Claims;

//namespace BookStore.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrderController : ControllerBase
//    {
//        private readonly IBookBL ibookBL;
//        private readonly IUserBL iuserBL;
//        private readonly IOrderBL iorderBL;
//        public OrderController(IBookBL bookBL, IUserBL userBL, IOrderBL orderBL)
//        {

//            ibookBL = bookBL;
//            iuserBL = userBL;
//            iorderBL = orderBL;

//        }

//        [HttpPost]
//        [Authorize]
//        public ResponceModel<OrderEntity> AddOrder(long bookId, int quantitys)
//        {
//            ResponceModel<OrderEntity> responce = new ResponceModel<OrderEntity>();
//            string userIdStr = User.FindFirstValue("UserId");
//            long userId = Convert.ToInt32(userIdStr);
//            try
//            {
//                OrderEntity order = iorderBL.AddOrder(bookId, quantitys, userId);
//                if (order != null)
//                {
//                    responce.Message = "Successfully added order";
//                    responce.Data = order;
//                }
//                else
//                {
//                    responce.Message = "Unable to add order";
//                    responce.IsSuccess = false;
//                }
//            }
//            catch(Exception ex) 
//            {
//                responce.IsSuccess=false;
//                responce.Message = ex.Message;
//            }
//            return responce;

//        }
//    }
//}
