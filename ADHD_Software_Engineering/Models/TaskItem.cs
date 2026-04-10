using System;
using System.ComponentModel.DataAnnotations;

namespace ADHD_Software_Engineering.Models
{
	public class TaskItem
	{
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public string Status { get; set; } = "Pending";

        public List<SubtaskItem> Subtasks { get; set; } = new();
    }
}

