using RepositoryLayer.Entitys;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        public OrderEntity AddOrder(long bookId, int quantitys, long userId);
    }
}
