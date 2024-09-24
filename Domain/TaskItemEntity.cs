using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    /// <summary>
    /// Task Item Entity
    /// </summary>
    public class TaskItemEntity
    {
        [Key]
        [Column("task_id")]
        public int TaskId { get; set; }

        [Column("task_title")]
        public required string TaskTitle { get; set; }

        [Column("task_description")]
        public string? TaskDescription { get; set; }

        [Column("task_status")]
        public string? TaskStatus { get; set; }
    }
}
