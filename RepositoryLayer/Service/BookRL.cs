using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class BookRL : IBookRL
    {
        private readonly BookStoreDBContext dBContext;
        public BookRL(BookStoreDBContext dBContext) 
        {
           this.dBContext = dBContext;
        }
        BooksEntity IBookRL.GetBookById(long bookId)
        {
            BooksEntity book = dBContext.Books.Find(bookId);
            return book;
        }
        //public IEnumerable<BooksEntity> GetAllBooks()
        //{
        //   return dBContext.Books;
        //}
    }
}
