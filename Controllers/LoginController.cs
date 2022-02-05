using HotelManagementWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {  //1 Depedency Injection Configuration
        private readonly IConfiguration _config;



        //2 Constructor Injection
        public LoginController(IConfiguration config)
        {
            _config = config;
        }




        //3 HTTP POST
        [HttpPost("token")]
        public IActionResult Login([FromBody] UserModel user)
        {
            //checkiing unauthorized
            IActionResult response = Unauthorized();

            //authenticate the user
            var loginUser = AuthenticateUser(user);

            //validate the user and generate jwt token
            if (loginUser != null)
            {
                var tokenString = GenerateJWToken(loginUser);
                response = Ok(new { token = tokenString });
            }

            // return Ok("Hello From API");
            return response;
        }






        //4.authentivcate user
        private UserModel AuthenticateUser(UserModel user)
        {
            UserModel loginUser = null;
            //Validate the user credentials
            //retrieve date from the database
            if (user.UserName == "Sameena")
            {
                loginUser = new UserModel
                {
                    UserName = "Sameena",
                    EmailAddress = "sameena@gmail.com",
                    DateOfJoining = new DateTime(2020, 12, 10),
                    Role = "Administrator"

                };
            }
            return loginUser;
        }

        //5.generate jwt token
        private string GenerateJWToken(UserModel loginUser)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //signing credential
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //claims---roles

            //genrate token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"], //header
                 _config["Jwt:Issuer"],
                 expires: DateTime.Now.AddMinutes(2),
                 signingCredentials: credentials
                    );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
