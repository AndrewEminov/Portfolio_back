using Portfolio.ModelsDTO;
using System.Threading.Tasks;

namespace Portfolio.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> AddNewUser(UserDTO user, string header);

        //        Task<int> AddNewUserOAuth(UserOAuthDTO user, string OAuthType);


        //        Task EditUserDTO(UserDTO user);
        //        Task RemoveUserDTO(int id);
        //        Task GetUserDTO(int id);

        Task<bool> CheckEmail(string email);
        Task<UserDTO> LoginUser(string email, string password);
        Task<UserDTO> LoginUserByOAuth(string email);
        Task<UserDTO> UserConfirm(string tokenEmail);
        Task<bool> ForgotPassword(string email, string url);
        Task<UserDTO> ResetPassword(string token, string newPassword);
    }
}