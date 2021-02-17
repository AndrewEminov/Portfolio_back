using AutoMapper;
using Portfolio.Models;
using Portfolio.ModelsDTO;

namespace Portfolio.Controllers.Infrastructure.Mappings
{
    public class UserMapperService : Profile
    {
        public UserMapperService()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}