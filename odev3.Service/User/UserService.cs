using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using odev3.DB.Models;
using odev3.Models.User;
namespace odev3.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public bool Login(LoginUserModel user)
        {
            bool result = false;
            var model = mapper.Map<odev3.DB.Models.User>(user);
            using (var srv = new ProjeContext())
            {
                result = srv.Users.Any(u => !u.IsDeleted && u.IsActive && u.Email == user.Email && u.Password == user.Password);
            }
            return result;
        }
        public UserListModel<UserViewModel> Get()
        {
            var result = new UserListModel<UserViewModel>();
            using (var srv = new ProjeContext())
            {
                var data = srv.Users.Where(
                 u => u.IsActive && !u.IsDeleted).OrderBy(u => u.Id);
                result.userList = mapper.Map<List<UserViewModel>>(data);

            }
            return result;
        }

        public bool Insert(odev3.DB.Models.User newUser)
        {
            var result = false;
            using (var srv = new ProjeContext())
            {

                srv.Users.Add(newUser);
                newUser.IsActive = true;
                newUser.IsDeleted = false;
                srv.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Update(UpdateUserModel updatedUser, int id)
        {
            bool result = false;
            using (var srv = new ProjeContext())
            {
                var data = srv.Users.SingleOrDefault(u => u.Id == id);
                if (data is null)
                {
                    return result;
                }
                data.Name = updatedUser.Name != default ? updatedUser.Name : data.Name;
                data.Surname = updatedUser.Surname != default ? updatedUser.Surname : data.Surname;
                data.Email = updatedUser.Email != default ? updatedUser.Email : data.Email;
                data.Password = updatedUser.Password != default ? updatedUser.Password : data.Password;

                srv.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            using (var srv = new ProjeContext())
            {
                var data = srv.Users.SingleOrDefault(u => u.Id == id);
                if (data is null)
                {
                    return result;
                }
                //DB'den silinmez, silindi olarak işaretlenir.
                srv.Users.SingleOrDefault(u => u.Id == id).IsDeleted = true;
                srv.Users.SingleOrDefault(u => u.Id == id).IsActive = false;
                srv.SaveChanges();
                result = true;
            }
            return result;
        }

    }
}