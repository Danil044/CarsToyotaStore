using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCarStore.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "InStepAuthAuthServer"; // издатель токена
        public const string AUDIENCE = "ITStepAuthClient"; // потребитель токена
        const string KEY = "5ylIJ1Ryr906SsLNn0PRKyibw95tAFReSieRtvZnwYddf1CCtCxYm3aZ8PxsBIG";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
