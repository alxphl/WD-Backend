using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WD.Entities;
using WD.Interfaces;

namespace WD.Services
{
    public class SecurityService : ISecurityService
    {
        //private IUserRepository UserRepository;
        private IConfiguration Config;
        public SecurityService(IConfiguration config)//,IUserRepository userRepository)
        {
           // UserRepository = userRepository;
            Config = config;
        }



        public User GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Jwt:Key"]));
            var credentials= new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.PlayId),
            };
            var token =new JwtSecurityToken(
                issuer:Config["Jwt:Issuer"],
                audience: Config["Jwt:Issuer"],
                claims,
                expires:DateTime.Now.AddMinutes(120),
                signingCredentials:credentials);

            var encodeToken=new JwtSecurityTokenHandler().WriteToken(token);
            user.Token = encodeToken;
            return user;

        }

    }
}
