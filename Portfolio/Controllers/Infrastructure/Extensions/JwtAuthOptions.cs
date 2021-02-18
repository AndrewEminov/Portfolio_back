using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Controllers.Infrastructure.Extensions
{
    public class JwtAuthOptions
    {
        public const string ISSUER = "MyPorfolio"; 
        public const string AUDIENCE = "MyPorfolio";
        const string KEY = "MyPorfolio_secretkey!123"; 
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
