using DTO_Models.DTOModels;
using Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Helpers
{
    public static class NoteHelper
    {
        public static void ValidateNoteEmptyString(NoteDTOM note)
        {
            if (string.IsNullOrEmpty(note.Text))
            {
                throw new NoteException(null, note.UserId, "Text field is required!");
            }
            if (note.Color.Count() < 3)
            {
                throw new NoteException(null, note.UserId, "Color field can not have less than 3 characters!");
            }
        }
        public static void ValidateNoteById(int? id)
        {
            if (id == null) throw new NoteException(id,0, "Invalid note ID!");
        }
    }
}
