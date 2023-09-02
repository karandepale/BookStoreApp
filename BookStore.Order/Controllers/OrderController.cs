using BookStore.Order.Entity;
using BookStore.Order.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBookRepo bookRepo;
        public OrderController(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }


        // GET BOOK DETAILS BY ID:
        [HttpGet]
        [Route("GetBook_Detail")]
        public async Task<IActionResult> GetBookDetails(int bookID)
        {
            BookEntity bookEntity = await bookRepo.GetBookDetails(bookID);
            if (bookEntity != null)
            {
                return Ok(bookEntity);
            }
            else
            {
                return BadRequest("Book Not Found.....");
            }
        }



    }
}
