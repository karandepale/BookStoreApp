using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Admin.Entity
{
    public class AdminEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AdminID { get; set; }


        //FIRST NAME:-
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[A-Za-z\s-]+$", ErrorMessage = "First name should only contain letters, spaces, or hyphens")]
        public string FirstName { get; set; }



        //LAST NAME:-
        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[A-Za-z\s-]+$", ErrorMessage = "Last name should only contain letters, spaces, or hyphens")]
        public string LastName { get; set; }



        //EMAIL ADDRESS:-
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }



        //PASSWORD:-
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one lowercase letter, one uppercase letter, one digit, and one special character.")]
        public string Password { get; set; }
    }
}
