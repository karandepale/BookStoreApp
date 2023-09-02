using BookStore.Books.Context;
using BookStore.Books.Entity;
using BookStore.Books.Interfaces;
using BookStore.Books.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Books.Services
{
    public class BookRepo : IBookRepo
    {
        private readonly BookContext bookContext;
        public BookRepo(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }


        //ADD BOOK:-
        public BookEntity AddBook(BookAddModel model)
        {
            try
            {
                BookEntity bookEntity = new BookEntity();
                bookEntity.BookName = model.BookName;
                bookEntity.Description = model.Description;
                bookEntity.Author = model.Author;
                bookEntity.Quantity = model.Quantity;
                bookEntity.DiscountPrice = model.DiscountPrice;
                bookEntity.ActualPrice = model.ActualPrice;

                bookContext.Book.Add(bookEntity);
                bookContext.SaveChanges();

                if (bookEntity != null)
                {
                    return bookEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }



        //Get ALL BOOKS:-
        public List<BookEntity> GetAllBooks()
        {
            try
            {
                var result = bookContext.Book.ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }




        // GET BOOK BY ID:-
        public BookEntity GetBookByID(long BookID)
        {
            try
            {
                var result = bookContext.Book.FirstOrDefault
                    (data => data.BookID == BookID);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }



        // UPDATE BOOK:-
        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult UpdateBook(BookEditModel model, long BookID)
        {
            var result = bookRepo.UpdateBook(model, BookID);
            if (result != null)
            {
                return Ok(new { success = true, message = "Book Updated Successfully", data = result });
            }
            else
            {
                return NotFound(new { success = false, message = "Book Not Updated.", data = result });
            }
        }

    }
}
