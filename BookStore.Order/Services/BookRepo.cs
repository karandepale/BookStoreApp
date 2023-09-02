using BookStore.Order.Entity;
using BookStore.Order.Interfaces;
using BookStore.Order.Model;
using Newtonsoft.Json;

namespace BookStore.Order.Services
{
    public class BookRepo : IBookRepo
    {
        private readonly IHttpClientFactory httpClientFactory;
        public BookRepo(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<BookEntity> GetBookDetails(int id)
        {
            var client = httpClientFactory.CreateClient("BookApi"); // named clinet configured
            var response = await client.GetAsync($"Book/GetBookByID?BookID={id}");

            if (response.IsSuccessStatusCode)
            {
                var apiResponseModel = await response.Content.ReadFromJsonAsync<ResponseModel>();
                if (apiResponseModel != null)
                {
                    var bookEntity = JsonConvert.DeserializeObject<BookEntity>(apiResponseModel.Data.ToString());
                    return bookEntity;
                }
            }

            return null;
        }


    }
}
