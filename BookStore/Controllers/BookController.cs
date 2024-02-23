using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entitys;
using System.Security.Claims;

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

        //[HttpGet("GetAllBooks")]
        //public ResponceModel<IEnumerable<BooksEntity>> GetAllBooks()
        //{
        //    ResponceModel<IEnumerable<BooksEntity>> responce = new ResponceModel<IEnumerable<BooksEntity>>();

        //    try
        //    {
        //        IEnumerable<BooksEntity> books = ibookBL.GetAllBooks();
        //        if (books != null)
        //        {
        //            responce.Message = "succesfully get books details";
        //            responce.Data = books;
        //        }
        //        else
        //        {
        //            responce.IsSuccess = false;
        //            responce.Message = "Book not find";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        responce.IsSuccess = false;
        //        responce.Message = ex.Message;
        //    }
        //    return responce;
        //}
    }
}
