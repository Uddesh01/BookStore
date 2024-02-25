using BusinessLayer.Interface;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL icartRL;
        public CartBL(ICartRL cartRL)
        {
            icartRL = cartRL;
        }
        CartEntity ICartBL.AddCart(long bookId, int quantitys, long userId)
        {
            return icartRL.AddCart(bookId, quantitys, userId);
        }
        public bool RemoveCartByCartId(long CartId, long userId)
        {
            return icartRL.RemoveCartByCartId(CartId, userId);
        }
        public IEnumerable<CartEntity> GetAllCartByUserID(long userId)
        {
            return  icartRL.GetAllCartByUserID(userId);
        }

        public CartEntity UpdateCart(long cartId, int quantitys, long userId)
        {
            return icartRL.UpdateCart(cartId, quantitys, userId);
        }
    }
}
