using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using odev3.Models;
using odev3.Service.User;
using odev3.Models.User;
using Microsoft.Extensions.Caching.Memory;
using odev3.API.Cache;

namespace odev3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IUserCache userCache;

        public UserController(IUserService _userService, IMapper _mapper, IUserCache _userCache)
        {
            userService = _userService;
            mapper = _mapper;
            userCache = _userCache;
        }
        [HttpGet]
        public UserListModel<UserViewModel> Get()
        {//kullanıcıları listelemek için giriş yapılması gereklidir.
            var user = new LoginUserModel();
            user = userCache.GetCachedUser();
            //cache'deki veri boş ise giriş yapılmamış demektir.
            if (user is null)
            {//giriş yapılmamış ise boş liste döner.
                var users = new UserListModel<UserViewModel>();
                return users;
            }
            //giriş kontrolünden sonra tam liste döner.
            return userService.Get();
        }

        [HttpPost]
        [Route("register")]
        public bool CreateUser([FromBody] CreateUserModel newUser)
        {
            bool result;
            var data = mapper.Map<odev3.DB.Models.User>(newUser);
            result = userService.Insert(data);
            return result;
        }

        [HttpPost]
        [Route("login")]
        public bool LoginUser([FromBody] LoginUserModel user)
        {
            if (userService.Login(user))//login işlemi başarılı ise 
            {//doğrulanan veri cachelenmek üzere ilgili fonksiyona gönderilir
                userCache.Cache(user);
                return true;
            }
            //login işlemi başarısız ise zaten yetki dönmez.
            return false;

        }

        [HttpPut]
        [Route("update")]
        public bool UpdateUser([FromBody] UpdateUserModel updatedUser, int id)
        {
            return userService.Update(updatedUser, id);
        }

        [HttpDelete]
        [Route("delete")]
        public bool DeleteUser(int id)
        {
            return userService.Delete(id);
        }


    }
}