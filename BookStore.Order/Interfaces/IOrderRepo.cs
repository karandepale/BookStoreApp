using BookStore.Order.Entity;

namespace BookStore.Order.Interfaces
{
    public interface IOrderRepo
    {
        public  Task<OrderEntity> PlaceOrder(int bookID, int quantity, string token);
        public  Task<IEnumerable<OrderEntity>> GetOrders(int userID, string token);
        public  Task<OrderEntity> GetOrdersByOrderID(int orderID, int userID, string token);
    }
}
