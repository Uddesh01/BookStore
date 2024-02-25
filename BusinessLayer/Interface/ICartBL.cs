using RepositoryLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public CartEntity AddCart(long bookId, int quantitys,long userId);
       public bool RemoveCartByCartId(long CartId,long userId);
       public IEnumerable<CartEntity> GetAllCartByUserID(long userId);
       public CartEntity UpdateCart(long cartId, int  quantitys, long userId);
    }
}
