using Domain;

namespace Application
{
    public class AddTaskItemUseCase<TDTO>
    {
        private readonly IRepository<TaskItemEntity> _taskItemRepository;
        private readonly IMapper<TDTO, TaskItemEntity> _mapper;

        public AddTaskItemUseCase(IRepository<TaskItemEntity> taskItemRepository,
            IMapper<TDTO, TaskItemEntity> mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(TDTO dto)
        {
            TaskItemEntity taskItem = 
                _mapper.ToMap(dto) ?? throw new Exception("There is an error creating the task item");

            if (string.IsNullOrEmpty(taskItem.TaskTitle))
            {
                throw new Exception("The task title is required!");
            }

            if (string.IsNullOrEmpty(taskItem.TaskStatus))
            {
                taskItem.TaskStatus = "Not Started";
            }

            await _taskItemRepository.AddTaskItemAsync(taskItem);
        }
    }
}
