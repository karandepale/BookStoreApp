using BookStore.Admin.Entity;

namespace BookStore.Admin.Models
{
    public class LoginResult
    {
        public AdminEntity AdminEntity { get; set; }
        public string JwtToken { get; set; }
    }
}
