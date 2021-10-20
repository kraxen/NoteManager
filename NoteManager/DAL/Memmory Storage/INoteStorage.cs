using NoteManager.DAL.Domain;
using System.Collections.Generic;

namespace NoteManager.DAL.Memmory_Storage
{
    public interface INoteStorage
    {
        void Add(Note note);
        void Delete(int id);
        IReadOnlyCollection<Note> GetAll();
        IReadOnlyCollection<Note> Search(string nameSearch, string TextSearch);
        Note GetById(int id);
    }
}

