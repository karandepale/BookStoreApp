using BookStore.Order.Context;
using BookStore.Order.Entity;
using BookStore.Order.Interfaces;

namespace BookStore.Order.Services
{
    public class OrderRepo : IOrderRepo
    {

        private readonly OrderContext orderContext;
        private readonly IBookRepo bookRepo;
        private readonly IUserRepo userRepo;
        public OrderRepo(OrderContext orderContext,IBookRepo bookRepo , IUserRepo userRepo)
        {
            this.orderContext = orderContext;
            this.bookRepo = bookRepo;
            this.userRepo = userRepo;
        }



        //PLACE ORDER:-
        public async Task<OrderEntity> PlaceOrder(int bookID, int quantity, string token)
        {

            BookEntity book = await bookRepo.GetBookDetails(bookID);
            UserEntity user = await userRepo.GetUserDetails(token);

            OrderEntity orderEntity = new OrderEntity();
            orderEntity.UserID = user.UserID;
            orderEntity.BuyQty = quantity;
            orderEntity.BookID = bookID;

            orderEntity.Book = book;
            orderEntity.User = user;

            orderEntity.OrderAmount = (book.ActualPrice - book.DiscountPrice) * quantity;

            if (user.UserID != null && bookID != null && quantity != 0)
            {
                orderContext.Order.Add(orderEntity);
                orderContext.SaveChanges();
                return orderEntity;
            }
            return null;

        }




        //GET ALL ORDERS:-
        public async Task<IEnumerable<OrderEntity>> GetOrders(int userID, string token)
        {
            IEnumerable<OrderEntity> result = orderContext.Order.Where(x => x.UserID == userID);

            if (result != null)
            {
                foreach (OrderEntity order in result)
                {
                    order.Book = await bookRepo.GetBookDetails(Convert.ToInt32(order.BookID));
                    order.User = await userRepo.GetUserDetails(token);
                }
                return result;
            }
            return null;
        }




        //GET ORDER BY ORDER-ID:-
        public async Task<OrderEntity> GetOrdersByOrderID(int orderID, int userID, string token)
        {
            OrderEntity orderEntity = orderContext.Order.Where(x => x.OrderID == orderID && x.UserID == userID).FirstOrDefault();
            if (orderEntity != null)
            {
                orderEntity.Book = await bookRepo.GetBookDetails(Convert.ToInt32(orderEntity.BookID));
                orderEntity.User = await userRepo.GetUserDetails(token);

                return orderEntity;
            }
            return null;
        }




        //REMOVE ORDER:-
        public bool RemoveOrder(int orderID, int userID)
        {
            OrderEntity orderEntity = orderContext.Order.Where(x => x.OrderID == orderID && x.UserID == userID).FirstOrDefault();
            if (orderEntity != null)
            {
                orderContext.Order.Remove(orderEntity);
                orderContext.SaveChanges();

                return true;
            }
            return false;
        }



    }
}
