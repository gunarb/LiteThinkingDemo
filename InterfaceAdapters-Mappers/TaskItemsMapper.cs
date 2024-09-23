using Application;
using Domain;
using InterfaceAdapters_Mappers.Dtos.Requests;

namespace InterfaceAdapters_Mappers
{
    public class TaskItemsMapper : IMapper<TaskItemRequestDTO, TaskItemEntity>
    {
        public TaskItemEntity ToMap(TaskItemRequestDTO dto) => new()
        {
            TaskTitle = dto.TaskTitle,
            TaskDescription = dto.TaskDescription,
            TaskStatus = dto.TaskStatus
        };
    }
}
