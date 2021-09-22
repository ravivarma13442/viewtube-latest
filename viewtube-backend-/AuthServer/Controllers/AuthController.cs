using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using AuthServer.Models;
using AuthServer.Services;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Exceptions;

namespace AuthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;
        public AuthController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                _service.RegisterUser(user);
                return StatusCode(201, "You are successfully registered!");
            }
            catch (UserAlreadyExistsException ue)
            {
                return Conflict(ue.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "There is some server error");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser([FromBody] LoginUser user)
        {
            try
            {
                string email = user.Email;
                string password = user.Password;

                User _user = _service.Login(email, password);

                //calling the function for the JWT token for respected user
                string value = this.GetJWTToken(email);
                //returning the token to the consumer app
                return Ok(value);
            }
            catch (UserNotFoundException unf)
            {
                return NotFound(unf.Message);
            }
            catch
            {
                return StatusCode(500, "Some server error");
            }
        }

        [HttpPost]
        [Route("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPassword user)
        {
            try
            {
                string email = user.Email;
                string oldPassword = user.OldPassword;
                string newPassword = user.NewPassword;

                User _user = _service.ResetPass(email, oldPassword, newPassword);

                return StatusCode(201, "Password has been reset successfully");
                
            }
            catch (UserNotFoundException unf)
            {
                return NotFound(unf.Message);
            }
            catch
            {
                return StatusCode(500, "Some server error");
            }
        }

        [HttpPost]
        [Route("forget-password")]
        public IActionResult ForgetPassword([FromBody] ForgetPassword user)
        {
            try
            {
                string email = user.Email;
                string newPassword = user.NewPassword;

                User _user = _service.ForgetPass(email, newPassword);

                return StatusCode(201, "Password has been reset successfully");
                
            }
            catch (UserNotFoundException unf)
            {
                return NotFound(unf.Message);
            }
            catch
            {
                return StatusCode(500, "Some server error");
            }
        }

        [HttpPost]
        [Route("user")]
        public IActionResult GetUser([FromQuery]string email)
        {
            try
            {
                var user = _service.FindByEmail(email);
                return StatusCode(200, user);
            }
            catch (UserNotFoundException ue)
            {
                return Conflict(ue.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "There is some server error");
            }
        }


        private string GetJWTToken(string email)
        {
            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.UniqueName, email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("authserver_secret_to_validate_token"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "AuthServer",
                audience: "jwtclient",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );
            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return JsonConvert.SerializeObject(response);
        }
    }
}
