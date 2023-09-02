﻿using BookStore.User.Context;
using BookStore.User.Entity;
using BookStore.User.Interfaces;
using BookStore.User.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.User.Services
{
    public class UserRepo : IUserRepo
    {
       
        private readonly UserContext userContext;
        private readonly IConfiguration configuration;
        public UserRepo(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        //USER REGISTRATION:-
        public UserEntity UserRegistration(UserRegistrationModel model)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = model.FirstName;
                userEntity.LastName = model.LastName;
                userEntity.Email = model.Email;
                userEntity.Password = model.Password;
                userEntity.Address = model.Address;

                userContext.User.Add(userEntity);
                userContext.SaveChanges();
                if (userEntity != null)
                {
                    return userEntity;
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



        // JWT TOKEN GENERATE:-
        public string GenerateJwtToken(string Email, long UserID)
        {
            var claims = new List<Claim>
            {
                new Claim("UserID", UserID.ToString()),
                new Claim(ClaimTypes.Email, Email),
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["JwtSettings:Issuer"], configuration["JwtSettings:Audience"], claims, DateTime.Now, DateTime.Now.AddHours(1), creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        //USER LOGIN:-
        public UserLoginResult UserLogin(UserLoginModel model)
        {
            try
            {
                var result = userContext.User.FirstOrDefault
                    (data => data.Email == model.Email && data.Password == model.Password);
                if (result != null)
                {
                    return new UserLoginResult
                    {
                        UserEntity = result,
                        JwtToken = GenerateJwtToken(result.Email, result.UserID)
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




    }
}
