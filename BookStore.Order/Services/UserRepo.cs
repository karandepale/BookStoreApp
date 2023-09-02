using BookStore.Order.Entity;
using BookStore.Order.Interfaces;
using BookStore.Order.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BookStore.Order.Services
{
    public class UserRepo : IUserRepo
    {

        private readonly IHttpClientFactory httpClientFactory;

        public UserRepo(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<UserEntity> GetUserDetails(string jwtToken)
        {
            var client = httpClientFactory.CreateClient("UserApi"); // named client configured

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);//AH

            var response = await client.GetAsync("User/GetUser_ByID");

            if (response.IsSuccessStatusCode)
            {
                var apiResponseModel = await response.Content.ReadFromJsonAsync<ResponseModel>();
                if (apiResponseModel != null)
                {
                    var userEntity = JsonConvert.DeserializeObject<UserEntity>(apiResponseModel.Data.ToString());
                    return userEntity;
                }
            }
            return null;
        }


    }
}
