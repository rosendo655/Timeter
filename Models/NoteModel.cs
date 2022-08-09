using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    public class NoteModel
    {
        public string Text { get; set; }
        public int Pinned { get; set; } = 0;
    }
}
