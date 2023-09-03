using BookStore.Order.Entity;

namespace BookStore.Order.Interfaces
{
    public interface IOrderRepo
    {
        public  Task<OrderEntity> PlaceOrder(int bookID, int quantity, string token);
    }
}
