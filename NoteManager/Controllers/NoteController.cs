using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoteManager.DAL.Memmory_Storage;
using NoteManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NoteManager.Controllers
{
    public class NoteController : Controller
    {
        private readonly ILogger<NoteController> _logger;
        private readonly INoteStorage _noteStorage;

        public NoteController(ILogger<NoteController> logger, INoteStorage noteStorage)
        {
            _logger = logger;
            _noteStorage = noteStorage;
        }

        public IActionResult GetNotes(string name, string text)
        {
            var notes = _noteStorage.Search(name,text);

            return Ok(notes);
        }
        public IActionResult GetById(int id)
        {
            var note = _noteStorage.GetById(id);

            return Ok(note);
        }
    }
}
