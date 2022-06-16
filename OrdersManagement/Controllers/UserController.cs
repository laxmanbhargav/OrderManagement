using Microsoft.AspNetCore.Mvc;
using OrderManagement.Core.Models;
using OrderManagement.Service.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdersManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LoginDto login)
        {
            try
            {
                var loginResponse = await _userService.GetUser(login);

                if (loginResponse != null)
                    return Ok(loginResponse);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
