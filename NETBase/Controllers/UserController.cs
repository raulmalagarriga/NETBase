using Microsoft.AspNetCore.Mvc;
using NETBase.DTOs;
using NETBase.Interfaces.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NETBase.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<UserDTO> Response = await _userService.GetUsers();
                return Ok(Response);
            }catch(Exception err)
            {
                return StatusCode(400, err.Message);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{code}")]
        public async Task<IActionResult> GetUserByCode(string code)
        {
            try
            {
                UserDTO Response = await _userService.GetUserByCode(code);
                return Ok(Response);
            }
            catch (Exception err)
            {
                return StatusCode(400, err.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserDTO data)
        {
            try
            {
                bool Response = await _userService.CreateUser(data);
                return StatusCode(201, "User created successfully!");
            }
            catch (Exception err)
            {
                return StatusCode(400, err.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                bool response = await _userService.DeleteUser(code);
                return StatusCode(200, "User deleted successfully!");
            }
            catch (Exception err)
            {
                return StatusCode(400, err.Message);
            }
        }
    }
}
