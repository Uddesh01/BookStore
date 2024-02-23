using BusinessLayer.Interface;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public  class BookBL:IBookBL
    {
        private readonly IBookRL ibookRL;
        public BookBL(IBookRL bookRL)
        {
            ibookRL = bookRL;
        }
        public BooksEntity GetBookById(long bookId)
        {
            return ibookRL.GetBookById(bookId);
        }

        //public IEnumerable<BooksEntity> GetAllBooks()
        //{
        //    return ibookRL.GetAllBooks();
        //}
    }
}
