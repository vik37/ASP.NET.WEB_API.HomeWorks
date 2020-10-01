using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SEDC.WebApi.Bonus_HomeWork.Model;

namespace SEDC.WebApi.Bonus_HomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return Ok(StaticDb.AllUsers);
        }

        [HttpPost]
        public ActionResult CreateUser()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Request.Body))
                {
                    var jsonBody = sr.ReadToEnd();
                    var user = JsonConvert.DeserializeObject<User>(jsonBody);
                    StaticDb.AllUsers.Add(user);
                    return StatusCode(StatusCodes.Status201Created, "User successfully created!");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
