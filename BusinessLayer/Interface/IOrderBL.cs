using RepositoryLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        public OrderEntity AddOrder(long bookId, int quantitys, long userId);
    }
}
