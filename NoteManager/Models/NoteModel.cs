using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteManager.Models
{
    public class NoteModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
