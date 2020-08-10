using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BPM_with_ASP.NET
{
    public class AuthOptions
    {
        public const string ISSUER = "localhost";
        public const string AUDIENCE = "localhost";
        const string KEY = "test_security_key";
        public const int LIFETIME = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
