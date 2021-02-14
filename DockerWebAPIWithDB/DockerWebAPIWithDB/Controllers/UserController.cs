using DockerWebAPIWithDB.BusinessLogic.Interface;
using DockerWebAPIWithDB.DTO;
using DockerWebAPIWithDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace DockerWebAPIWithDB.Controllers
{

    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {

        private readonly IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpGet]
        [Route("{UserName}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserResponseDTO))]
        public IActionResult GetUserName(string UserName)
        {
            return new OkObjectResult(_userBL.GetUser(UserName));
        }

        [HttpPost]
        [Route("AddUser")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IActionResult))]
        public IActionResult AddUser([FromBody] UserRequestDTO user)
        {
            _userBL.AddUser(user);
            return new OkResult();
        }

        [HttpPost]
        [Route("Authenticate")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(bool))]
        public IActionResult CheckSecurity([FromHeader] String username, [FromHeader] String password)
        {
            return new OkObjectResult(_userBL.AuthenticateUser(username, password));
        }
    }
}
