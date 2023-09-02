namespace BookStore.Order.Model
{
    public class ResponseModel
    {
        public object? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string message { get; set; }
    }
}
