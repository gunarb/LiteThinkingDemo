using Application;
using Domain;
using InterfaceAdapters_Data;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters_Repository
{
    public class TaskRepository : IRepository<TaskItemEntity>
    {
        // ***** TODO convert TaskItemEntity to TaskItem ***** 

        private readonly AppDbContext _dbContext;

        public TaskRepository(AppDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Add a Task Item into the data base
        /// </summary>
        /// <param name="taskItemEntity">Task Item Entity object</param>
        /// <returns></returns>
        public async Task AddTaskItemAsync(TaskItemEntity taskItemEntity)
        {
            //TaskItem taskItem = new()
            //{
            //    TaskTitle = taskItemEntity.TaskTitle,
            //    TaskDescription = taskItemEntity.TaskDescription,
            //    TaskStatus = taskItemEntity.TaskStatus
            //};

            await _dbContext.TaskItems.AddAsync(taskItemEntity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get a Task Item from the data base based on its id
        /// </summary>
        /// <param name="id">Task Item Id</param>
        /// <returns></returns>
        public async Task<TaskItemEntity> GetByIdAsync(int id)
        {
            TaskItemEntity? taskItem = await _dbContext.TaskItems.FindAsync(id);
            return taskItem ?? throw new Exception(string.Format("Task with id={0} not found", id));
        }

        /// <summary>
        /// Get all the Task Items from the data base
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TaskItemEntity>> GetAllAsync()
        {
            return await _dbContext.TaskItems.ToListAsync();
        }
    }
}
