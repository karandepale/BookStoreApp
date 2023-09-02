using BookStore.User.Interfaces;
using BookStore.User.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo userRepo;
        public UserController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }


        //USER REGISTRATION:-
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(UserRegistrationModel model)
        {
            var result = userRepo.UserRegistration(model);
            if (result != null)
            {
                return Ok(new { success = true, message = "User Registration Successful", data = result });
            }
            else
            {
                return BadRequest(new { success = false, message = "User Registration Failed", data = result });
            }
        }



        //USER LOGIN:-
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult Login(UserLoginModel model)
        {
            var result = userRepo.UserLogin(model);
            if (result != null)
            {
                return Ok(new { success = true, message = "User Login Successful", data = result });
            }
            else
            {
                return BadRequest(new { success = false, message = "User Login Failed", data = result });
            }
        }


    }
}
