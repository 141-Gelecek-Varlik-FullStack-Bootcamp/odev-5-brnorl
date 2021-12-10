using AutoMapper;
using odev3.DB.Models;
using odev3.Models.User;

namespace odev3.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CREATE
            CreateMap<User, CreateUserModel>();
            CreateMap<CreateUserModel, User>();
            //GET
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
            //LOGIN
            CreateMap<User, LoginUserModel>();
            CreateMap<LoginUserModel, User>();

        }
    }
}