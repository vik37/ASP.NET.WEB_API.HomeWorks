﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class NoteController : ControllerBase
    {
        private INoteServices _noteService;
        private IUserServices _userService;
        public NoteController(INoteServices noteService, IUserServices userService)
        {
            _noteService = noteService;
            _userService = userService;
        }
        // GET: api/<NoteController>
        [HttpGet]
        public ActionResult<List<NoteDTOM>> Get()
        {
            try
            {
                return Ok(_noteService.GetAllNotes());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public ActionResult<NoteDTOM> Get(int id)
        {
            try
            {
                return Ok(_noteService.GetNoteById(id));
            }
            catch (NoteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<NoteController>
        [HttpPost]
        public ActionResult Post([FromQuery]int userId, [FromBody] NoteDTOM note)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                note.UserId = userId;
                _noteService.AddNote(note);
                return Ok("Note successfully created");
            }
            catch (NoteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<NoteController>/5
        [HttpPut]
        public ActionResult Put([FromBody] NoteDTOM note)
        {
            try
            {
                var dbNote = _noteService.GetNoteById(note.Id);
                _noteService.UpdateNote(note);
                return Ok("Note updated successfully");
            }
            catch (NoteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _noteService.DeleteNote(id);
                return Ok("note successfully deleted");
            }
            catch (NoteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
