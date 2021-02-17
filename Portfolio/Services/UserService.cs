using AutoMapper;
using Portfolio.Models;
using Portfolio.ModelsDTO;
using Portfolio.Repositories.Interfaces;
using Portfolio.Services.Infrastructure;
using Portfolio.Services.Infrastructure.Extensions;
using Portfolio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> AddNewUser(UserDTO userDTO, string header)
        {
            var user = _mapper.Map<User>(userDTO);

            user.IdentityToken = CryptoExtension.ToMD5(RandomToken.RandomString(10));

            var newUser = await _userRepository.Create(user);

            if (newUser == null)
            {
                return null;
            }

            //  EmailExtension.sendEmail(newUser, url);

            return _mapper.Map<UserDTO>(newUser);
        }
        
        public async Task<bool> CheckEmail(string email)
        {
            return await _userRepository.CheckUserByEmail(email);
        }

        // 2
        public async Task<UserDTO> LoginUser(string email, string password)
        {
            string passwordHash = CryptoExtension.ToMD5(password);

            var user = await _userRepository.GetUserByEmail(email);

            if (user?.Password == passwordHash && user?.Email == email && user.IsConfirmed)
            {
                return _mapper.Map<UserDTO>(user);
            }

            return null;
        }

        public Task<bool> ForgotPassword(string email, string url)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> LoginUserByOAuth(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> ResetPassword(string token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UserConfirm(string tokenEmail)
        {
            throw new NotImplementedException();
        }
    }
}
