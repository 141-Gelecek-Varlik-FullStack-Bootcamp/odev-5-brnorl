using System.Collections.Generic;
using odev3.Models.User;

namespace odev3.Service.User
{
    public interface IUserService
    {
        public bool Insert(odev3.DB.Models.User newUser);

        public UserListModel<UserViewModel> Get();

        public bool Login(LoginUserModel user);
        public bool Update(UpdateUserModel updatedUser, int id);

        public bool Delete(int id);
    }
}