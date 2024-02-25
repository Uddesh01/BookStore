using RepositoryLayer.Entitys;
using RepositoryLayer.Service;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        public CartEntity AddCart(long bookId, int quantitys, long userId);
        public bool RemoveCartByCartId(long CartId, long userId);
        public IEnumerable<CartEntity> GetAllCartByUserID(long userId);
        public CartEntity UpdateCart(long cartId, int quantitys, long userId);
    }
}
