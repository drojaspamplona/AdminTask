using System;

namespace AdminTask.Models
{

    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }
    }
    
    public enum TaskStatus
    {
        Pending,
        Completed
    }
}