﻿using CommonLayer.Model;
using RepositoryLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public  interface IBookRL
    {
        public BooksEntity GetBookById(long bookId);
        public IEnumerable<BooksEntity> GetAllBooks();
        public BooksEntity AddBook(AddBookModel newBook);
        public bool DeleteBook(long bookId);
        public BooksEntity UpdateBook(BooksEntity updateBook,long bookId);
    }
}
