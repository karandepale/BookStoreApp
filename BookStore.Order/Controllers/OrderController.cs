using BookStore.Order.Entity;
using BookStore.Order.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBookRepo bookRepo;
        private readonly IUserRepo userRepo;
        private readonly IOrderRepo orderRepo;
        public OrderController(IBookRepo bookRepo, IUserRepo userRepo, IOrderRepo orderRepo)
        {
            this.bookRepo = bookRepo;
            this.userRepo = userRepo;
            this.orderRepo = orderRepo;
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



        // PLACE ORDER:-
        [Authorize]
        [HttpPost]
        [Route("Place_Order")]
        public async Task<IActionResult> PlaceOrder(int bookID, int quantity)
        {
            string token = Request.Headers.Authorization.ToString();
            token = token.Substring("Bearer ".Length);

            OrderEntity orderEntity = await orderRepo.PlaceOrder(bookID, quantity, token);
            if (orderEntity != null)
            {
                return Ok(orderEntity);
            }
            return BadRequest("Unable to place order...");
        }




        //GET ALL ORDER:-
        [Authorize]
        [HttpGet]
        [Route("GetAll_Orders")]
        public async Task<IActionResult> GetOrders()
        {
            string token = Request.Headers.Authorization.ToString();
            token = token.Substring("Bearer ".Length);

            int userID = Convert.ToInt32(User.FindFirstValue("UserID"));

            IEnumerable<OrderEntity> orderEntity = await orderRepo.GetOrders(userID, token);
            if (orderEntity != null)
            {
                return Ok(orderEntity);
            }
            return BadRequest("Unable to get order...");
        }




        // GET ORDER BY ID:-
        [Authorize]
        [HttpGet]
        [Route("GetOrderBy_ID")]
        public async Task<IActionResult> GetOrdersByOrderID(int orderID)
        {
            string token = Request.Headers.Authorization.ToString();
            token = token.Substring("Bearer ".Length);

            int userID = Convert.ToInt32(User.FindFirstValue("UserID"));

            OrderEntity orderEntity = await orderRepo.GetOrdersByOrderID(orderID, userID, token);
            if (orderEntity != null)
            {
                return Ok(orderEntity);
            }
            return BadRequest("Unable to get order by id...");
        }




        //REMOVE ORDER BY ORDER-ID:-
        [Authorize]
        [HttpDelete("removeOrder")]
        public IActionResult RemoveOrder(int orderID)
        {
            int userID = Convert.ToInt32(User.FindFirstValue("UserID"));
            bool isRemove = orderRepo.RemoveOrder(orderID, userID);
            if (isRemove != null)
            {
                return Ok(isRemove);
            }
            return BadRequest("Unable to get order by id...");
        }






    }
}
