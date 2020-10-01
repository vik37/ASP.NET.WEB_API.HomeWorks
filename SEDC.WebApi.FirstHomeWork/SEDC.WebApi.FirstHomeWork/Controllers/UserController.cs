using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEDC.WebApi.FirstHomeWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<string> userNames = new List<string>() { "Viktor", "Pero", "Kate", "Marinko", "Maja", "Svetlana", "Sabri" };
       
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, userNames);
           
        }

        [HttpGet("{id:int}")]
        public ActionResult<string> GetUser(int id)
        {
            if (id < 0) return StatusCode(StatusCodes.Status400BadRequest, new
            {
                message = "Can be lower then 0!"
            });
            if (id >= userNames.Count) return StatusCode(StatusCodes.Status404NotFound);
            return Ok(userNames[id]);
        }

        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Request.Body))
                {
                    string name = sr.ReadToEnd();
                    userNames.Add(name);
                    return StatusCode(StatusCodes.Status201Created, "Note was succesfully!");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });
            }           
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            string user = userNames[id];
            if (user == null) return BadRequest($"There is no user with index {id}");
            userNames.Remove(user);
            return Ok($"User with name {user} is successfully deleted");
        }
    }
}
