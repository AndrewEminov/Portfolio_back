using AutoMapper;
using Portfolio.ModelsDTO;
using Portfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers.Infrastructure.Mappings
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserViewModel, UserDTO>().ReverseMap();
        }
    }
}
