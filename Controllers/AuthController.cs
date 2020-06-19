using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.Models;
using AutoMapper;
using MediatR;
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
        private readonly IMediator _mediator;
        public AuthController (IConfiguration confirugation, IMediator mediator) {
            this._configuration = confirugation;
            this._mediator = mediator;
        }

        [HttpPost ("Login")]
        public async Task<IActionResult> Login ([FromBody] UserAuthCommand command) {
            // User login = new User ();
            // login.UserName = username;
            // login.Password = password;
            var result = await _mediator.Send (command);
            return Ok (result);
            // IActionResult response = Unauthorized ();

            // var user = AuthenticateUser (login);
            // if (user != null) {
            //     var tokenStr = GenerateJSONWebToken (user);
            //     response = Ok (new { token = tokenStr, user = user });
            // }
            // return response;
        }

        private User AuthenticateUser (User loginUser) {
            User user = null;
            if (loginUser.UserName == "akash" && loginUser.Password == "123456") {
                user = new User { UserName = "Akash", Email = "akash.corp@akij.net", FirstName = "Maniruzzaman", LastName = "Akash", Password = "123456", Gender = true };
            }
            return user;
        }

    }
}