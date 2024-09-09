using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Category { get; set; }
        public bool IsCompleted { get; set; }
    }

    public enum Priority
    {
        High,
        Medium,
        Low
    }

}
