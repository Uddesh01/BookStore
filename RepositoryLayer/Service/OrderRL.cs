using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class OrderRL : IOrderRL
    {
        private readonly BookStoreDBContext dbContext;
        private readonly IBookRL ibookRL;
        public OrderRL(BookStoreDBContext dbContext, IBookRL bookRL)
        {
            this.dbContext = dbContext;
            this.ibookRL = bookRL;
        }
        OrderEntity IOrderRL.AddOrder(long bookId, int quantitys, long userId)
        {
            BooksEntity book = ibookRL.GetBookById(bookId);
            int amount = quantitys * book.Price;
            OrderEntity newOrder = new OrderEntity
            {
                Quantity = quantitys,
                UserID = userId,
                OrderAmount = amount,
                CreatedAt = DateTime.UtcNow
            };
            dbContext.Add(newOrder);
            dbContext.SaveChanges();
            return newOrder;
        }
    }
}
