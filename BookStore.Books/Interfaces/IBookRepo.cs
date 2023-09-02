﻿using BookStore.Books.Entity;
using BookStore.Books.Model;

namespace BookStore.Books.Interfaces
{
    public interface IBookRepo
    {
        public BookEntity AddBook(BookAddModel model);
    }
}
