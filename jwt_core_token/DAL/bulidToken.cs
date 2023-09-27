using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace jwt_core_token.DAL
{
    public class bulidToken
    {
        public string creatToken()
        {
            var byts = Encoding.UTF8.GetBytes("Asp.netcore");
            SymmetricSecurityKey key = new SymmetricSecurityKey(byts);

            SigningCredentials  credentials =new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now.AddMinutes(1)
                ,signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }
}
