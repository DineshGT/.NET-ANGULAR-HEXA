using System.ComponentModel.DataAnnotations;

namespace CodingChallenge1.Models
{
    public enum Priority { Low, Medium, High }
    public enum Status { Pending, InProgress, Completed }

    public class TaskItem
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
