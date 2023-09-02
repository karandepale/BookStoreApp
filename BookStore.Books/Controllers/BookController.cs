using BookStore.Books.Interfaces;
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



    }
}
