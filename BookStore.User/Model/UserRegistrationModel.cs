using BookStore.User.Context;
using System.ComponentModel.DataAnnotations;

namespace BookStore.User.Model
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name must contain only letters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last Name must contain only letters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and include at least one lowercase letter, one uppercase letter, and one digit.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}
