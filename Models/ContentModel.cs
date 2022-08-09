using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    public class ContentModel
    {
        public List<TaskModel> Tasks { get; set; }
        public List<NoteModel> QuickNotes { get; set; }
        public List<NoteModel> LongNotes { get; set; }
    }
}
