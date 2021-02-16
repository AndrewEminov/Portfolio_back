/*using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class AuthController : ControllerBase
    {
        private string headerOrigin = "https://localhost:44386"; // Request.Headers.TryGetValue("origin", out);


        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<User>> Login(LoginUserViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.LoginUser(data.Login, data.Password);

            if (user == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = user.Email
            };

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<User>> Register(UserDTO data)
        {
            bool checkEmail = await _userService.CheckEmail(data.Email);

            if (!checkEmail)
            {
                var client = await _userService.AddNewUser(data, this.headerOrigin);
                return Ok(client);

            }
            else
            {
                return BadRequest(new { errorText = "Email already exist" });
            }
        }

        [Route("google-auth")]
        [HttpPost]
        public async Task<ActionResult<object>> GoogleAuth(string providerToken)
        {
            string GoogleApiTokenInfoUrl = "https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={0}";

            var httpClient = new HttpClient();
            var requestUri = new Uri(string.Format(GoogleApiTokenInfoUrl, providerToken));

            HttpResponseMessage httpResponseMessage;
            try
            {
                httpResponseMessage = await httpClient.GetAsync(requestUri);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest();
            }

            var response = httpResponseMessage.Content.ReadAsStringAsync().Result;

            var googleAuthUser = JsonConvert.DeserializeObject<GoogleUserDTO>(response);



            *//* if (googleAuthUser.aud)
             {
                return BadRequest();
            }*//*

            bool checkEmail = await _userService.CheckEmail(googleAuthUser.email);

            UserOAuthDTO setUser = new UserOAuthDTO
            {
                Email = googleAuthUser.email,
                Name = googleAuthUser.name,
                GoogleAuth = true,
            };

            if (!checkEmail)
            {
                var client = await _userService.AddNewUserOAuth(setUser, "google");
            }

            var user = await _userService.LoginUserByOAuth(setUser.Email);

            if (user == null)
            {
                return BadRequest(new { errorText = "Error" });
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);


            return Ok(new { access_token = encodedJwt, username = user.Email });
        }

        [HttpPost("[action]")]
        [HttpPost("[action]")]
        public async Task<ActionResult<User>> ProfileConfirmation(string tokenEmail)
        {

            var user = await _userService.UserConfirm(tokenEmail);

            if (user == null)
            {
                return BadRequest(new { errorText = "Confirm is invalid" });
            }

            return Ok(user);

        }

        [HttpPost("[action]")]
        public async Task<ActionResult<bool>> ForgotPassword(string email)
        {
            bool isSuccess = await _userService.ForgotPassword(email, this.headerOrigin);

            if (isSuccess)
            {
                return Ok(new { successText = "We sent a message, check your email" });
            }
            else
            {
                return BadRequest(new { errorText = "Email is not found" });
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<User>> ResetPassword(string token, string newPassword)
        {
            var user = await _userService.ResetPassword(token, newPassword);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }
    }
}
*/