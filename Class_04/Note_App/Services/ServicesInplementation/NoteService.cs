using Data.Interfaces;
using Domain_Models.Models;
using DTO_Models.DTOModels;
using Mappings.Mapper;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ServicesInplementation
{
    public class NoteService : INoteServices
    {
        private IRepository<Note> _noteRepo;
        public NoteService(IRepository<Note> noteRepo)
        {
            _noteRepo = noteRepo;
        }
        public List<NoteDTOM> GetAllNotes()
        {
            var note = _noteRepo.GetAll().ToList();
            return NoteMapper.NotesToNotesModels(note);
        }

        public NoteDTOM GetNoteById(int id)
        {
            var note = _noteRepo.GetById(id);
            NoteHelper.ValidateNoteById(note.Id);
            return NoteMapper.NoteToNoteModel(note);
        }

        public void AddNote(NoteDTOM noteModel)
        {
            NoteHelper.ValidateNoteEmptyString(noteModel);
            var note = NoteMapper.NoteModelToNote(noteModel);
               _noteRepo.Insert(note);
        }

        public void UpdateNote(NoteDTOM noteModel)
        {
            var noteCheck = _noteRepo.GetById(noteModel.Id);
            NoteHelper.ValidateNoteById(noteCheck.Id);
            NoteHelper.ValidateNoteEmptyString(noteModel);
            var note = NoteMapper.NoteModelToNote(noteModel);
            _noteRepo.Update(note);
        }

        public void DeleteNote(int id)
        {
            var note = GetNoteById(id);
            NoteHelper.ValidateNoteById(note.Id);
            _noteRepo.Remove(id);
        }

       
    }
}
