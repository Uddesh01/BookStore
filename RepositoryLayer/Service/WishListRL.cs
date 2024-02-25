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

        public bool RemoveFromWishList(long userId, long bookId)
        {
            WishListEntity wishList = dbContext.WishLists.FirstOrDefault(w => w.UserId == userId && w.BookId == bookId);
            if (wishList != null)
            {
                dbContext.WishLists.Remove(wishList);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
