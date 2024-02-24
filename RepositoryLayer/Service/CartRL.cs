using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    
    
    public  class CartRL:ICartRL
    {
        private readonly BookStoreDBContext dbContext;
        private readonly IBookRL ibookRL;

        public CartRL(BookStoreDBContext dbContext, IBookRL bookRL)
        {
            this.dbContext = dbContext;
            ibookRL = bookRL;
        }
        public CartEntity AddCart(long bookId, int quantitys, long userId)
        {
            BooksEntity book = ibookRL.GetBookById(bookId);
            int amount = book.Price * quantitys;
            CartEntity newCartItem = new CartEntity
            {
                UserId= userId,
                BookId= bookId,
                Quantitys= quantitys,
                Amount=amount,
                isOrdered=false
            };
            dbContext.Carts.Add(newCartItem);
            dbContext.SaveChanges();
            return newCartItem;
        }
        public bool RemoveCartByCartId(long cartId,long userId)
        {
            
            CartEntity cart = dbContext.Carts.Where(c => c.CartId == cartId && c.UserId==userId).FirstOrDefault();
            if (cart != null)
            {
                dbContext.Carts.Remove(cart);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<CartEntity> GetAllCartByUserID(long userId)
        {
            IEnumerable<CartEntity> carts = dbContext.Carts.Where(c => c.UserId==userId);
            if(carts!=null)
            {
                return carts;
            }
            return null;
        }
    }
}
