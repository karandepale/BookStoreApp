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
        public string FirstName { get; set; }


        //LAST NAME:-
        public string LastName { get; set; }


        //EMAIL ADDRESS:-
        public string Email { get; set; }


        //PASSWORD:-
        public string Password { get; set; }
    }
}
