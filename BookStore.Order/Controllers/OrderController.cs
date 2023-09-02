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
        private readonly IUserRepo userRepo;
        public OrderController(IBookRepo bookRepo, IUserRepo userRepo)
        {
            this.bookRepo = bookRepo;
            this.userRepo = userRepo;
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



        // GET USER DETAILS:
        [HttpGet]
        [Route("GetUser_Details")]
        public async Task<IActionResult> GetUserDetails()
        {
            string token = Request.Headers.Authorization.ToString();
            token = token.Substring("Bearer ".Length);

            UserEntity user = await userRepo.GetUserDetails(token);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest("unable to get user");
        }
    }
}
