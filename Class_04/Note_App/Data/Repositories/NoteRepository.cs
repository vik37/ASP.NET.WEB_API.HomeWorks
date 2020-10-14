using Data.DatabaseContext;
using Data.Interfaces;
using Domain_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class NoteRepository : IRepository<Note> 
    {
        private NotesDbContext _context;
        public NoteRepository(NotesDbContext context)
        {
            _context = context;
        }
        public ICollection<Note> GetAll()
        {
            return _context.Notes.ToList();
        }

        public Note GetById(int id)
        {
            return GetAll().SingleOrDefault(n => n.Id == id);
        }

        public void Insert(Note entity)
        {
            _context.Notes.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var noteToBeRemoved = _context.Notes.SingleOrDefault(n => n.Id == id);
            if (noteToBeRemoved == null) return;
            _context.Notes.Remove(noteToBeRemoved);
            _context.SaveChanges();
        }

        public void Update(Note entity)
        {
            _context.Notes.Add(entity);
            _context.SaveChanges();
        }
    }
}
