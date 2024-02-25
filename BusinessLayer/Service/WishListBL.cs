using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class WishListBL:IWishListBL
    {
        private readonly IWishListRL iwishListRL;

        public WishListBL(IWishListRL wishListRL)
        {
            iwishListRL = wishListRL;
        }
        public bool AddToWishList(long userId, long bookId)
        {
            return iwishListRL.AddToWishList(userId, bookId);
        }
        public bool RemoveFromWishList(long userId, long bookId)
        {
            return iwishListRL.RemoveFromWishList(userId,bookId);
        }
    }
}
