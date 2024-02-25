using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class OrderBL : IOrderBL
    {
        private readonly IOrderRL iorderRL;
        public OrderBL(IOrderRL orderRL)
        {
            iorderRL = orderRL;
        }
        OrderSummary IOrderBL.AddOrder(long cartId, long userId)
        {
            return iorderRL.AddOrder(cartId, userId);
        }
        IEnumerable<OrderSummary> IOrderBL.GetAllOrdersDetails(long userId)
        {
            return iorderRL.GetAllOrdersDetails(userId);
        }
        public bool RemoveOrder(long orderId)
        {
            return iorderRL.RemoveOrder(orderId);
        }
        public OrderSummary GetOrderByOrderId(long orderId)
        {
            return iorderRL.GetOrderByOrderId(orderId);
        }
    }
}
