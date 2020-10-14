using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTO_Models.DTOModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Note_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserServices _userService;
        public UsersController(IUserServices userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<UserDTOM>> Get()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDTOM> Get(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                if (user == null) return BadRequest("Invalid user id");
                return Ok(user);
            }
            catch (UserException ex)
            {
                Debug.WriteLine($"User id {ex.UserId}, message: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] UserDTOM user)
        {
            try
            {
                _userService.AddUser(user);
                return Ok("User created successfully");
            }
            catch (UserException ex)
            {
                Debug.WriteLine($"User ID {ex.UserId}, message: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] UserDTOM user)
        {
            try
            {
                _userService.UpdateUser(user);
                return Ok("User updated successfully");
            }
            catch (UserException ex)
            {
                Debug.WriteLine($"User id {ex.UserId}, message: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok("User deleted successfully");
            }
            catch (UserException ex)
            {
                Debug.WriteLine($"User id {ex.UserId}, message: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
