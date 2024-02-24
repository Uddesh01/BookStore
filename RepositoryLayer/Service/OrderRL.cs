//using RepositoryLayer.Entitys;
//using RepositoryLayer.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RepositoryLayer.Service
//{
//    public class OrderRL : IOrderRL
//    {
//        private readonly BookStoreDBContext dbContext;
//        private readonly IBookRL ibookRL;
//        public OrderRL(BookStoreDBContext dbContext, IBookRL bookRL)
//        {
//            this.dbContext = dbContext;
//            this.ibookRL = bookRL;
//        }
//        OrderEntity IOrderRL.AddOrder(long bookId, int quantitys, long userId)
//        {
//            BooksEntity book = ibookRL.GetBookById(bookId);
//            int amount = quantitys * book.Price;
//            OrderEntity newOrder = new OrderEntity
//            {
//                Quantity = quantitys,
//                UserID = userId,
//                OrderAmount = amount,
//                CreatedAt = DateTime.UtcNow
//            };
//            dbContext.Add(newOrder);
//            dbContext.SaveChanges();
//            return newOrder;
//        }

//        public IEnumerable<OrderEntity> GetOrders(long userId)
//        {
//            IEnumerable<OrderEntity> orders = dbContext.Orders.Where(o => o.UserID == userId);
//            if (orders != null)
//            {
//                return orders;
//            }
//            else
//            {
//                throw new Exception("User or notes are not found!!");
//            }
//        }

//        public OrderEntity GetOrderByOrderID(int orderId, int userId)
//        {
//            OrderEntity orderEntity = dbContext.Orders.Where(x => x.OrderID == orderId && x.UserID == userId).FirstOrDefault();
//            if (orderEntity != null)
//            {
//              return orderEntity;
//            }
//            return null;
//        }

//        public bool RemoveOrder(int orderId, int userId)
//        {
//            OrderEntity orderEntity = dbContext.Orders.Where(x => x.OrderID == orderId && x.UserID == userId).FirstOrDefault();
//            if (orderEntity != null)
//            {
//                dbContext.Orders.Remove(orderEntity);
//                dbContext.SaveChanges();
//                return true;
//            }
//            return false;
//        }
//    }
//}
