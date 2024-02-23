using CommonLayer.Model;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class BookRL : IBookRL
    {
        private readonly BookStoreDBContext dBContext;
        public BookRL(BookStoreDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public BooksEntity GetBookById(long bookId)
        {
            BooksEntity book = dBContext.Books.Find(bookId);
            return book;
        }
        public IEnumerable<BooksEntity> GetAllBooks()
        {
            return dBContext.Books;
        }

        public BooksEntity AddBook(AddBookModel newBook)
        {
            BooksEntity newBookEntity = new BooksEntity
            {
                BookName = newBook.BookName,
                Author = newBook.Author,
                Price = newBook.Price,
                BookImage = newBook.BookImage,
                Quantity = newBook.Quantity,
                AddedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
            };
            dBContext.Books.Add(newBookEntity);
            dBContext.SaveChanges();
            return newBookEntity;
        }

        public bool DeleteBook(long bookId)
        {
            BooksEntity book = dBContext.Books.Where(b => b.Book_ID == bookId).FirstOrDefault();
            if (book != null)
            {
                dBContext.Books.Remove(book);
                dBContext.SaveChanges();
                return true;
            }
            return false;
        }
        public BooksEntity UpdateBook(BooksEntity updateBook, long bookId)
        {
            BooksEntity book = dBContext.Books.Where(b => b.Book_ID == bookId).FirstOrDefault();
            if (book != null)
            {
                book.BookName = updateBook.BookName;
                book.Author = updateBook.Author;
                book.Price = updateBook.Price;
                book.BookImage = updateBook.BookImage;
                book.Quantity = updateBook.Quantity;
                book.UpdatedOn = DateTime.UtcNow;
                dBContext.Books.Update(book);
                dBContext.SaveChanges();
                return book;

            }
            return null;
        }
    }
}
