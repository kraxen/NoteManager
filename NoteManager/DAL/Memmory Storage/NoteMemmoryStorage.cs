using NoteManager.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteManager.DAL.Memmory_Storage
{
    public class NoteMemmoryStorage : INoteStorage
    {
        private readonly List<Note> _notes;
        private int _lastId;

        public NoteMemmoryStorage()
        {
            _lastId = 1;
            _notes = new List<Note>
            {
                new Note
                {
                    Id = _lastId++,
                    Name = "Test Note 1",
                    Text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi obcaecati facilis harum iusto dolor doloribus impedit dolore ducimus ab asperiores. Consectetur doloremque in omnis voluptatum, blanditiis tenetur nostrum suscipit perferendis."
                },
                new Note
                {
                    Id = _lastId++,
                    Name = "Test Note 2",
                    Text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi obcaecati facilis harum iusto dolor doloribus impedit dolore ducimus ab asperiores. Consectetur doloremque in omnis voluptatum, blanditiis tenetur nostrum suscipit perferendis."
                },
                new Note
                {
                    Id = _lastId++,
                    Name = "Test Note 3",
                    Text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Modi obcaecati facilis harum iusto dolor doloribus impedit dolore ducimus ab asperiores. Consectetur doloremque in omnis voluptatum, blanditiis tenetur nostrum suscipit perferendis."
                }
            };
        }
        public void Add(Note note)
        {
            note.Id = _lastId++;
            _notes.Add(note);
        }
        public void Delete(int id)
        {
            Note note = _notes.FirstOrDefault(x => x.Id == id);
            _notes.Remove(note);
        }
        public IReadOnlyCollection<Note> GetAll()
        {
            return _notes;
        }
        public IReadOnlyCollection<Note> Search(string nameSearch, string TextSearch)
        {
            var result = _notes.AsQueryable();

            if (!string.IsNullOrEmpty(nameSearch))
            {
                result = result.Where(x => x.Name.Contains(nameSearch.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(TextSearch))
            {
                result = result.Where(x => x.Text.Contains(TextSearch.Trim(), StringComparison.OrdinalIgnoreCase));
            }
            return result.ToList();
        }
        public Note GetById(int id)
        {
            return _notes.FirstOrDefault(x => x.Id == id);
        }
        public bool IsNameUnique(string name)
        {
            return _notes.FirstOrDefault(x => x.Name == name) == null;
        }
    }
}
