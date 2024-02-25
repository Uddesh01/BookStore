using CommonLayer.Model;
using RepositoryLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        public OrderSummary AddOrder(long cartId,long userId);
        public IEnumerable<OrderSummary> GetAllOrdersDetails(long userId);
        public bool RemoveOrder(long orderId);
        public OrderSummary GetOrderByOrderId(long orderId);

    }
}
