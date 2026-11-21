#nullable enable
using BlazorApp.Application.Common.Interfaces;
using BlazorApp.Application.Common.Interfaces.Services;
using BlazorApp.Web.Data.Models;
using MongoDB.Driver;

namespace BlazorApp.Application.Services
{
    public class NotesService : INotesService
    {
        private readonly IApplicationDbContext _context;

        public NotesService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Notes> Get()
        {
            return _context.Notes.Find(FilterDefinition<Notes>.Empty).ToList();
        }

        public Notes? Get(string id)
        {
            return _context.Notes.Find(x => x._id == id).FirstOrDefault();
        }

        public Notes Create(Notes notes)
        {
            _context.Notes.InsertOne(notes);
            return notes;
        }

        public void Update(string id, Notes updatedNotes)
        {
            _context.Notes.ReplaceOne(x => x._id == id, updatedNotes);
        }

        public void Delete(Notes notesForDeletion)
        {
            if (notesForDeletion._id != null)
            {
                Delete(notesForDeletion._id);
            }
        }

        public void Delete(string id)
        {
            _context.Notes.DeleteOne(x => x._id == id);
        }
    }
}

