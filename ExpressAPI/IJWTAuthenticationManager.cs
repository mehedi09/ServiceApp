

using ExpressAPI.DAL;
using ExpressAPI.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace ExpressAPI
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        LoyalityServiceDAL _Loyality = new LoyalityServiceDAL();
        BasicUtilities _BasicUtilities = new BasicUtilities();
        private readonly string tokenKey;
        public JWTAuthenticationManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        public string Authenticate(string _UserName, string _Password)
        {
            DataTable result = _Loyality.CheckService_Client(_UserName, _Password);
            if (result.Rows.Count > 0)
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = System.Text.Encoding.ASCII.GetBytes(tokenKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, _UserName)
                    }),
                    Expires = System.DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
                //   return null;
            }
            else
            {
                return null;
            }
        }
    }
}