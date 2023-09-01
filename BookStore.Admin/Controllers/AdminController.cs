using BookStore.Admin.Interfaces;
using BookStore.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepo adminRepo;
        public AdminController(IAdminRepo adminRepo)
        {
            this.adminRepo = adminRepo;
        }


        //ADMIN REGISTRATION:-
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(AdminRegistrationModel model)
        {
            var result = adminRepo.Registration(model);
            if (result != null)
            {
                return Ok(new { success = true, message = "Admin Registration Successful", data = result });
            }
            else
            {
                return BadRequest(new { success = false, message = "Admin Registration Failed", data = result });
            }
        }



        //ADMIN LOGIN:-
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(AdminLoginModel model)
        {
            var result = adminRepo.AdminLogin(model);
            if (result != null)
            {
                return Ok(new { success = true, message = "Admin Login Successful", data = result });
            }
            else
            {
                return NotFound(new { success = false, message = "Admin Login Failed", data = result });

            }
        }

    }
}
