using CommonLayer.Model;
using RepositoryLayer.Entitys;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        public OrderSummary AddOrder(long cardId, long userId);
        public IEnumerable<OrderSummary> GetAllOrdersDetails(long userId);
        public bool RemoveOrder(long orderId);
        public OrderSummary GetOrderByOrderId(long orderId);

    }
}
