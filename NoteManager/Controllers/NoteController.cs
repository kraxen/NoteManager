using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public NoteController(ILogger<NoteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
