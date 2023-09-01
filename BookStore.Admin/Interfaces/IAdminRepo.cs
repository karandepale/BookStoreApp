using BookStore.Admin.Entity;
using BookStore.Admin.Models;

namespace BookStore.Admin.Interfaces
{
    public interface IAdminRepo
    {
        public AdminEntity Registration(AdminRegistrationModel model);
    }
}
