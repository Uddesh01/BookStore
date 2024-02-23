using RepositoryLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public  interface IBookBL
    {
        public BooksEntity GetBookById(long bookId);
        public IEnumerable<BooksEntity> GetAllBooks();
    }
}
