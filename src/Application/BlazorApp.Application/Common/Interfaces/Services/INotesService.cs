#nullable enable
using BlazorApp.Web.Data.Models;

namespace BlazorApp.Application.Common.Interfaces.Services
{
    public interface INotesService
    {
        List<Notes> Get();
        Notes? Get(string id);
        Notes Create(Notes notes);
        void Update(string id, Notes updatedNotes);
        void Delete(Notes notesForDeletion);
        void Delete(string id);
    }
}

