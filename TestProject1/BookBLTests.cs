using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Moq;
using RepositoryLayer.Entitys;
using RepositoryLayer.Interface;

namespace TestProject1
{
    public class BookBLTests
    {
        public Mock<IBookRL> mockBookRL;
        public IBookBL bookBL;

        [SetUp]
        public void Setup()
        {
            mockBookRL = new Mock<IBookRL>();
            mockBookRL.Setup(repo => repo.AddBook(It.IsAny<AddBookModel>()))
                .Returns(new BooksEntity
                {
                    Book_ID = 1,
                    BookName = "Test",
                    BookImage = "test.com",
                    Price = 10,
                    Quantity = 100
                });
            bookBL = new BookBL(mockBookRL.Object);
        }

        [Test]
        public void AddBookTest()
        {
            var newBook = new AddBookModel
            {
                BookName = "Test",
                BookImage = "test.com",
                Price = 10,
                Quantity = 100
            };

            var result = bookBL.AddBook(newBook);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Book_ID);
            Assert.AreEqual(newBook.BookName, result.BookName);
            Assert.AreEqual(result.BookImage, result.BookImage);
            Assert.AreEqual(newBook.Price, result.Price);
            Assert.AreEqual(newBook.Quantity, result.Quantity);

            mockBookRL.Verify(repo => repo.AddBook(It.IsAny<AddBookModel>()), Times.Once);
        }

        [Test]
        public void UpdateBookTest()
        {

            var updatedBook = new BooksEntity
            {
                Book_ID = 1,
                BookName = "Updated Test",
                BookImage = "updated_test.com",
                Price = 20,
                Quantity = 200
            };
            long bookId = 1;

            mockBookRL.Setup(repo => repo.UpdateBook(It.IsAny<BooksEntity>(), bookId))
                .Returns(updatedBook);


            var result = bookBL.UpdateBook(updatedBook, bookId);


            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Book_ID);
            Assert.AreEqual(updatedBook.BookName, result.BookName);
            Assert.AreEqual(updatedBook.BookImage, result.BookImage);
            Assert.AreEqual(updatedBook.Price, result.Price);
            Assert.AreEqual(updatedBook.Quantity, result.Quantity);


            mockBookRL.Verify(repo => repo.UpdateBook(updatedBook, bookId), Times.Once);
        }
        [Test]
        public void DeleteBookTest()
        {
            long bookId = 1;

            mockBookRL.Setup(repo => repo.DeleteBook(bookId))
                .Returns(true);

            var result = bookBL.DeleteBook(bookId);

            Assert.IsTrue(result);

            mockBookRL.Verify(repo => repo.DeleteBook(bookId), Times.Once);
        }
        [Test]
        public void GetAllBooks()
        {
            var expectedBooks = new List<BooksEntity>
            {
               new BooksEntity {Book_ID=1,BookName="Book 1",BookImage="book1.com"},
               new BooksEntity {Book_ID=2,BookName="Book 2",BookImage="book2.com"}
            };

            mockBookRL.Setup(repo => repo.GetAllBooks())
                .Returns(expectedBooks);

            IEnumerable<BooksEntity> result = bookBL.GetAllBooks();

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedBooks.Count, result.Count());
        }

    }
}
