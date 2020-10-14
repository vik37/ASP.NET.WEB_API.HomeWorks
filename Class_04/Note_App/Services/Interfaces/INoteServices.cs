using Domain_Models.Models;
using DTO_Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface INoteServices
    {
        List<NoteDTOM> GetAllNotes();
        NoteDTOM GetNoteById(int id);
        void AddNote(NoteDTOM note);
        void UpdateNote(NoteDTOM note);
        void DeleteNote(int id);
    }
}
