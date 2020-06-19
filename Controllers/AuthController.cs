using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using APIFuelStation.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APIFuelStation.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class AuthController : ControllerBase {

        private readonly IConfiguration _configuration;
        public AuthController (IConfiguration confirugation) {
            this._configuration = confirugation;
        }

        [HttpPost ("Login")]
        public IActionResult Login (string username, string password) {
            User login = new User ();
            login.UserName = username;
            login.Password = password;

            IActionResult response = Unauthorized ();

            var user = AuthenticateUser (login);
            if (user != null) {
                var tokenStr = GenerateJSONWebToken (user);
                response = Ok (new { token = tokenStr, user = user });
            }
            return response;
        }

        private User AuthenticateUser (User loginUser) {
            User user = null;
            if (loginUser.UserName == "akash" && loginUser.Password == "123456") {
                user = new User { UserName = "Akash", Email = "akash.corp@akij.net", FirstName = "Maniruzzaman", LastName = "Akash", Password = "123456", Gender = true };
            }
            return user;
        }

        private string GenerateJSONWebToken (User user) {
            var securityKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials (securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new [] {
                new Claim (JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim (JwtRegisteredClaimNames.Email, user.Email),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ())
            };

            var token = new JwtSecurityToken (
                issuer: _configuration["Jwt:Issuer"],
                audience : _configuration["Jwt:Issuer"],
                claims,
                expires : DateTime.Now.AddMinutes (120),
                signingCredentials : credentials
            );

            var encodenToken = new JwtSecurityTokenHandler ().WriteToken (token);
            return encodenToken;

        }
    }
}