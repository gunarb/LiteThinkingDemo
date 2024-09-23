namespace InterfaceAdapters_Mappers.Dtos.Requests
{
    public class TaskItemRequestDTO
    {
        public int TaskId { get; set; }
        public required string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string? TaskStatus { get; set; }
    }
}
