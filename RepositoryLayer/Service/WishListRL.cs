using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class WishListRL : IWishListRL
    {
        private readonly BookStoreDBContext dbContext;
        public WishListRL(BookStoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddToWishList(long userId, long bookId)
        {
            WishListEntity wishList = new WishListEntity
            {
                UserId = userId,
                BookId = bookId
            };
            dbContext.WishLists.Add(wishList);
            dbContext.SaveChanges();
            return true;
        }
    }
}
