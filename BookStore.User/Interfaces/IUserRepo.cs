﻿using BookStore.User.Entity;
using BookStore.User.Model;

namespace BookStore.User.Interfaces
{
    public interface IUserRepo
    {
        public UserEntity UserRegistration(UserRegistrationModel model);
        public UserLoginResult UserLogin(UserLoginModel model);
    }
}
