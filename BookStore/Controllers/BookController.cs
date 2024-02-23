using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entitys;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL ibookBL;
        public BookController(IBookBL bookBL)
        {
            ibookBL = bookBL;
        }

        [HttpGet("GetBookById")]
        public ResponceModel<BooksEntity> GetBookById(long bookId)
        {
            ResponceModel<BooksEntity> responce = new ResponceModel<BooksEntity>();
            try
            {
                BooksEntity book = ibookBL.GetBookById(bookId);
                if (book != null)
                {
                    responce.Message = "succesfully get books details";
                    responce.Data = book;
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Book not find";
                }

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        [HttpGet("GetAllBooks")]
        public ResponceModel<IEnumerable<BooksEntity>> GetAllBooks()
        {
            ResponceModel<IEnumerable<BooksEntity>> responce = new ResponceModel<IEnumerable<BooksEntity>>();

            try
            {
                IEnumerable<BooksEntity> books = ibookBL.GetAllBooks();
                if (books != null)
                {
                    responce.Message = "succesfully get books details";
                    responce.Data = books;
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Book not find";
                }

            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddNewBook")]
        public ResponceModel<BooksEntity> AddBook(AddBookModel newBook)
        {
            ResponceModel<BooksEntity> responce = new ResponceModel<BooksEntity>();
            try
            {
                BooksEntity addedBook = ibookBL.AddBook(newBook);
                if (addedBook != null)
                {
                    responce.Message = "Book Added Succesfully";
                    responce.Data = addedBook;
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Unable to add book";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteBook")]
        public ResponceModel<string> DeleteBook(long bookId)
        {
            ResponceModel<string> responce = new ResponceModel<string>();
            try
            {
                bool result = ibookBL.DeleteBook(bookId);
                if (result)
                {
                    responce.Message = "Book deleted succesfully";
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Unable to delete book";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateByBookId")]
        public ResponceModel<BooksEntity> UpdateBook(BooksEntity updateBook, long bookId)
        {
            ResponceModel<BooksEntity> responce = new ResponceModel<BooksEntity>();
            BooksEntity book = ibookBL.UpdateBook(updateBook, bookId);
            try
            {
                if (book != null)
                {
                    responce.Message = "Book updated successfully";
                    responce.Data = book;
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Unable to update book";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
    }
}
