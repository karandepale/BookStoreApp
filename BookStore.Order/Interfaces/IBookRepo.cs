using BookStore.Order.Entity;

namespace BookStore.Order.Interfaces
{
    public interface IBookRepo
    {
        public  Task<BookEntity> GetBookDetails(int id);
    }
}
