using CommonLayer.Model;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer.Service
{
    public class OrderRL : IOrderRL
    {
        private readonly BookStoreDBContext dbContext;

        public OrderRL(BookStoreDBContext dbContext, IBookRL bookRL)
        {
            this.dbContext = dbContext;        
        }

        public OrderSummary AddOrder(long cartId, long userId)
        {
            CartEntity cart = dbContext.Carts.FirstOrDefault(c => c.CartId == cartId && c.UserId == userId);
            if (cart != null)
            {
                OrderEntity newOrder = new OrderEntity
                {
                    CreatedAt = DateTime.UtcNow,
                    CartId = cartId
                };
                dbContext.Add(newOrder);
                dbContext.SaveChanges();

                cart.isOrdered = true;
                dbContext.Carts.Update(cart);
                dbContext.SaveChanges();

                OrderSummary orderSummary = new OrderSummary
                {
                    OrderId = newOrder.OrderID,
                    BookId = cart.BookId,
                    Quantitys = cart.Quantitys,
                    Amount = cart.Amount,
                    CreatedAt = newOrder.CreatedAt
                };
                return orderSummary;
            }
            return null;
        }

        public IEnumerable<OrderSummary> GetAllOrdersDetails(long userId)
        {
            var orders = (from order in dbContext.Orders
                          join cart in dbContext.Carts on order.CartId equals cart.CartId
                          join book in dbContext.Books on cart.BookId equals book.Book_ID
                          where cart.UserId == userId
                          select new OrderSummary
                          {
                              OrderId = order.OrderID,
                              BookId = cart.BookId,
                              BookName = book.BookName,
                              Author = book.Author,
                              BookImage = book.BookImage,
                              Quantitys = cart.Quantitys,
                              Amount = cart.Amount,
                              CreatedAt = order.CreatedAt
                          }).ToList();

            if (orders.Any())
            {
                return orders;
            }
            else
            {
                throw new Exception("No orders found for the specified user.");
            }
        }

        public bool RemoveOrder(long orderId)
        {
            OrderEntity orderToRemove = dbContext.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (orderToRemove != null)
            {
                dbContext.Orders.Remove(orderToRemove);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public OrderSummary GetOrderByOrderId(long orderId)
        {
            var order = (from o in dbContext.Orders
                         join cart in dbContext.Carts on o.CartId equals cart.CartId
                         join book in dbContext.Books on cart.BookId equals book.Book_ID
                         where o.OrderID == orderId
                         select new OrderSummary
                         {
                             OrderId = o.OrderID,
                             BookId = cart.BookId,
                             BookName = book.BookName,
                             Author = book.Author,
                             BookImage = book.BookImage,
                             Quantitys = cart.Quantitys,
                             Amount = cart.Amount,
                             CreatedAt = o.CreatedAt
                         }).FirstOrDefault();

            if (order != null)
            {
                return order;
            }
            else
            {
                throw new Exception("Order not found.");
            }
        }
    }
}
