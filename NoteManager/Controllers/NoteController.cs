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
        [HttpGet]
        public IActionResult GetNotes(NoteModel model)
        {
            var notes = _noteStorage.Search(model.Name, model.Text);

            return Ok(notes);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var note = _noteStorage.GetById(id);

            return Ok(note);
        }
        [HttpPost]
        public IActionResult Create([FromBody] NoteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_noteStorage.IsNameUnique(model.Name))
            {
                ModelState.AddModelError(nameof(model.Name), "Name should be uniqie");
                return BadRequest(ModelState);
            }

            _noteStorage.Add(new DAL.Domain.Note
            {
                Name = model.Name,
                Text = model.Text
            });
            return Ok();
        }
    }
}
