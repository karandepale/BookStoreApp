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



    }
}
