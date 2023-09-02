﻿using BookStore.Books.Interfaces;
using BookStore.Books.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BookStore.Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo bookRepo;
        public BookController(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }


        // ADD BOOK:-
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook(BookAddModel model)
        {
            var result = bookRepo.AddBook(model);
            if (result != null)
            {
                return Ok(new { success = true, message = "Book Added Successful", data = result });
            }
            else
            {
                return BadRequest(new { success = false, message = "Book Not Added.", data = result });
            }
        }



        // GET ALL BOOKS:-
        [HttpGet]
        [Route("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var result = bookRepo.GetAllBooks();
            if (result != null)
            {
                return Ok(new { success = true, message = "Book List Getting Successful", data = result });
            }
            else
            {
                return NotFound(new { success = false, message = "Books Not Found.", data = result });
            }
        }



        // GET BOOK BY ID:-
        [HttpGet]
        [Route("GetBookByID")]
        public IActionResult GetBookByID(long BookID)
        {
            var result = bookRepo.GetBookByID(BookID);
            if (result != null)
            {
                return Ok(new { success = true, message = "Book By ID Getting Successful", data = result });
            }
            else
            {
                return NotFound(new { success = false, message = "Book Not Found.", data = result });
            }
        }



        // UPDATE BOOK:-
        [Authorize(Roles = "Admin")]
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



        //DELETE BOOK:-
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(long BookID)
        {
            try
            {
                bookRepo.DeleteBook(BookID);
                return Ok(new { success = true, message = "Book Deleted Successfully" });
            }
            catch (System.Exception)
            {
                return NotFound(new { success = false, message = "Book Not Deleted." });
                throw;
            }
        }
    }
}
