using BookStore.Admin.Context;
using BookStore.Admin.Entity;
using BookStore.Admin.Interfaces;
using BookStore.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Admin.Services
{
    public class AdminRepo  : IAdminRepo
    {
        private readonly IConfiguration configuration;
        private readonly AdminContext adminContext;
        public AdminRepo(AdminContext adminContext, IConfiguration configuration)
        {
            this.adminContext = adminContext;
            this.configuration = configuration;
        }


<<<<<<< HEAD
        //USER REGISTRATION:-
=======
        //ADMIN REGISTRATION:-
>>>>>>> Admin_Login_API
        public AdminEntity Registration(AdminRegistrationModel model)
        {
            try
            {
                AdminEntity adminEntity = new AdminEntity();
                adminEntity.FirstName = model.FirstName;
                adminEntity.LastName = model.LastName;
                adminEntity.Email = model.Email;
                adminEntity.Password = model.Password;

                adminContext.Admin.Add(adminEntity);
                adminContext.SaveChanges();
                if (adminEntity != null)
                {
                    return adminEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Registration Failed Due to some Exception", e);
            }
        }


        //GENERATE JWT TOKEN:-
        public string GenerateJwtToken(string Email, long AdminID)
        {
            var claims = new List<Claim>
            {
                new Claim("AdminID", AdminID.ToString()),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Role,"Admin")
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["JwtSettings:Issuer"], configuration["JwtSettings:Audience"], claims, DateTime.Now, DateTime.Now.AddHours(1), creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
<<<<<<< HEAD
        
=======


        //ADMIN LOGIN:-
        public LoginResult AdminLogin(AdminLoginModel model)
        {
            try
            {
                var result = adminContext.Admin.FirstOrDefault
                    (data => data.Email == model.Email && data.Password == model.Password);
                if (result != null)
                {
                    return new LoginResult
                    {
                        AdminEntity = result,
                        JwtToken = GenerateJwtToken(result.Email, result.AdminID)
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

>>>>>>> Admin_Login_API


    }
}
