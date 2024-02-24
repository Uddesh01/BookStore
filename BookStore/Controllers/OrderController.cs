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
//            catch (Exception ex)
//            {
//                responce.IsSuccess = false;
//                responce.Message = ex.Message;
//            }
//            return responce;
//        }

//        [Authorize]
//        [HttpGet("getOrders")]
//        public ResponceModel<IEnumerable<OrderEntity>> GetOrders()
//        {
//            int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
//            ResponceModel<IEnumerable<OrderEntity>> responce = new ResponceModel<IEnumerable<OrderEntity>>();
//            try
//            {
//                IEnumerable<OrderEntity> orderEntity = iorderBL.GetOrders(userId);
//                if (orderEntity != null)
//                {
//                    responce.Message = "Successfully get all orders";
//                    responce.Data = orderEntity;
//                }
//                else
//                {
//                    responce.IsSuccess = false;
//                    responce.Message = "Unable to get all orders";
//                }
//            }
//            catch (Exception ex)
//            {
//                responce.Message = ex.Message;
//                responce.IsSuccess = false;
//            }
//            return responce;
//        }
//    }
//}
