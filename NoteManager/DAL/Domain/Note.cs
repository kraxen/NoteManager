﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteManager.DAL.Domain
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
