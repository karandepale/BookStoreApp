using BookStore.User.Context;
using BookStore.User.Entity;
using BookStore.User.Interfaces;
using BookStore.User.Model;

namespace BookStore.User.Services
{
    public class UserRepo : IUserRepo
    {
       
        private readonly UserContext userContext;
        public UserRepo(UserContext userContext)
        {
            this.userContext = userContext;
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


    }
}
