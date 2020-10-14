using Domain_Models.Models;
using DTO_Models.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mappings.Mapper
{
    public static class NoteMapper
    {
        public static NoteDTOM NoteToNoteModel(Note note)
        {
            return new NoteDTOM()
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = note.Tag,
                UserId = note.UserId
            };
        }
        public static Note NoteModelToNote(NoteDTOM note)
        {
            return new Note()
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = note.Tag,
                UserId = note.UserId
            };
        }
        public static List<NoteDTOM> NotesToNotesModels(List<Note> notes)
        {
            return notes.Select(note => new NoteDTOM()
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = note.Tag,
                UserId = note.UserId
            }).ToList();
        }
        public static List<Note> NotesModelsToNotes(List<NoteDTOM> notes)
        {
            return notes.Select(note => new Note()
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = note.Tag,
                UserId = note.UserId
            }).ToList();

        }
    }
}
