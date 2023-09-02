using BookStore.Order.Entity;

namespace BookStore.Order.Interfaces
{
    public interface IUserRepo
    {
        public  Task<UserEntity> GetUserDetails(string jwtToken);
    }
}
