using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APIFuelStation.CommandBus;
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
            var result = await _mediator.Send (command);
            return Ok (result);
        }

        [HttpPost ("Register")]
        public async Task<IActionResult> Register ([FromBody] UserRegisterCommand command) {
            var result = await _mediator.Send (command);
            return Ok (result);
        }

    }
}