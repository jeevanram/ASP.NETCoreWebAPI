using DockerWebAPIWithDB.BusinessLogic.Interface;
using DockerWebAPIWithDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(User))]
        public IActionResult GetUserName(string UserName)
        {
            return new OkObjectResult(_userBL.GetUser(UserName));
        }
    }
}
