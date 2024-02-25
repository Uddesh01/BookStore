using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entitys;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBL iorderBL;
        public OrderController(IOrderBL orderBL)
        {
            iorderBL = orderBL;
        }

        [HttpPost("AddOrder")]
        [Authorize]
        public ResponceModel<OrderSummary> AddOrder(long cartId)
        {
            ResponceModel<OrderSummary> responce = new ResponceModel<OrderSummary>();
            try
            {
                string userIdStr = User.FindFirstValue("UserId");
                long userId = Convert.ToInt32(userIdStr);
                OrderSummary orderSummary = iorderBL.AddOrder(cartId,userId);
                if (orderSummary != null)
                {
                    responce.Message = "Successfully added order";
                    responce.Data = orderSummary;
                }
                else
                {
                    responce.Message = "Unable to add order";
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

        [Authorize]
        [HttpGet("GetAllOrdersDetails")]
        public ResponceModel<IEnumerable<OrderSummary>> GetOrders()
        {
            int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
            ResponceModel<IEnumerable<OrderSummary>> responce = new ResponceModel<IEnumerable<OrderSummary>>();
            try
            {
                IEnumerable<OrderSummary> allOrders = iorderBL.GetAllOrdersDetails(userId);
                if (allOrders != null)
                {
                    responce.Message = "Successfully get all orders";
                    responce.Data = allOrders;
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Unable to get all orders";
                }
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.IsSuccess = false;
            }
            return responce;
        }
        [Authorize]
        [HttpGet("GetOrderByOrderId")]
        public ResponceModel<OrderSummary> GetOrderByOrderId(long orderId)
        {
            ResponceModel<OrderSummary> responce = new ResponceModel<OrderSummary>();
            try
            {
                OrderSummary orderSummary = iorderBL.GetOrderByOrderId(orderId);
                if (orderSummary != null)
                {
                    responce.Message = "Successfully retrieved order";
                    responce.Data = orderSummary;
                }
                else
                {
                    responce.Message = "Order not found or unauthorized access";
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

        [Authorize]
        [HttpDelete("RemoveOrder")]
        public ResponceModel<bool> RemoveOrder(long orderId)
        {
            ResponceModel<bool> responce = new ResponceModel<bool>();
            try
            {
                bool isRemoved = iorderBL.RemoveOrder(orderId);
                if (isRemoved)
                {
                    responce.Message = "Order removed successfully";
                    responce.Data = true;
                }
                else
                {
                    responce.Message = "Order not found or unauthorized access";
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
