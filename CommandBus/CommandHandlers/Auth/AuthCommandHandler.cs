using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using APIFuelStation.ViewModel;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace APIFuelStation.CommandBus {
    public class AuthCommandHandler : IRequestHandler<UserAuthCommand, TokenViewModel> {

        private readonly IUserRepository _userrepository;
        private readonly IConfiguration _configuration;

        public AuthCommandHandler (IUserRepository userrepository, IConfiguration configuration) {
            this._userrepository = userrepository;
            this._configuration = configuration;
        }
        public async Task<TokenViewModel> Handle (UserAuthCommand request, CancellationToken cancellationToken) {
            var user = _userrepository.GetUserByEmail (request.Email);
            var userByUserName = _userrepository.GetUserByUserName (request.Email);
            var userByPhoneNo = _userrepository.GetUserByPhoneNo (request.Email);

            if (user != null) {
                return GetTokenView (user, request);
            } else if (userByUserName != null) {
                return GetTokenView (userByUserName, request);
            } else if (userByPhoneNo != null) {
                return GetTokenView (userByPhoneNo, request);
            }

            return new TokenViewModel { Token = null, User = null };
        }

        public TokenViewModel GetTokenView (User user, UserAuthCommand request) {
            if (user != null) {
                if (BCrypt.Net.BCrypt.Verify (request.Password, user.Password)) {
                    var tokenStr = GenerateJSONWebToken (user);
                    var response = new { token = tokenStr, user = user };
                    return new TokenViewModel { Token = response.token, User = user };
                }
            }
            return new TokenViewModel { Token = null, User = null };
        }

        public string GenerateJSONWebToken (User user) {
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