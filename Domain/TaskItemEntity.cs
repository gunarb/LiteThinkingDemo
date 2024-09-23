namespace Domain
{
    /// <summary>
    /// Task Item Entity
    /// </summary>
    public class TaskItemEntity
    {
        public int TaskId { get; set; }
        public required string TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        public string? TaskStatus { get; set; }
    }
}
