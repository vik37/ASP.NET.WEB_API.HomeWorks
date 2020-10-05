using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.ASP.NET.WEB_API.SecondHomeWork_Movies.Model;

namespace SEDC.ASP.NET.WEB_API.SecondHomeWork_Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Movie>> GetMovie()
        {
            return Ok(StaticDb.GetMovies);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Movie>> GetMovieById(int id)
        {
            if (id < 1) return StatusCode(StatusCodes.Status400BadRequest, new
            { message = "Can not be lower then 1!" });
            var movie = StaticDb.GetMovies.SingleOrDefault(m => m.Id == id);
            if (movie == null) return StatusCode(StatusCodes.Status404NotFound);

            return Ok(movie);
        }

        [HttpPost]
        public ActionResult<List<Movie>> CreateMovie([FromBody] Movie movie)
        {
            try
            {
                StaticDb.GetMovies.Add(movie);
                return StatusCode(StatusCodes.Status201Created,"Movie successfully created");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet("QueryFilms")]
        public ActionResult<List<Movie>> GetByQueryParam(string name, double duration)
        {
            if (name.Length < 1 || duration < 1) return StatusCode(StatusCodes.Status400BadRequest, new
            {
                message = "Name can not be less then 1 charachter and duration can not be 0!"
            });
            var movie = StaticDb.GetMovies.Where(m => m.Name == name || m.Duration == duration).SingleOrDefault();
            if (movie == null) return StatusCode(StatusCodes.Status404NotFound, "Movies can not be found");

            return Ok(movie);

        }
    }
}
