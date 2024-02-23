using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class BookBL : IBookBL
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

        public IEnumerable<BooksEntity> GetAllBooks()
        {
            return ibookRL.GetAllBooks();
        }

        public BooksEntity AddBook(AddBookModel newBook)
        {
            return ibookRL.AddBook(newBook);
        }

        public bool DeleteBook(long bookId)
        {
            return ibookRL.DeleteBook(bookId);
        }
        public BooksEntity UpdateBook(BooksEntity updateBook,long bookId)
        {
            return ibookRL.UpdateBook(updateBook,bookId);
        }
    }
}
