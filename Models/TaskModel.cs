using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public TaskModelStatus TaskStatus { get; set; }
        public long Seconds { get; set; }
    }
    public enum TaskModelStatus
    {
        NONE,
        RUNNING,
        PAUSED,
    }
}
