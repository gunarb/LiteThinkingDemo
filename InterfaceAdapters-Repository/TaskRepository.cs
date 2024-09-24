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
            // TODO: use TaskItem instead of TaskItemEntity
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
        /// Delete a record from the DB based on the task id
        /// </summary>
        /// <param name="id">Task id</param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(int id)
        {
            var taskItem = await GetByIdAsync(id);

            _ = _dbContext.TaskItems.Remove(taskItem);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get all the Task Items from the data base
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TaskItemEntity>> GetAllAsync()
        {
            return await _dbContext.TaskItems.ToListAsync();
        }

        /// <summary>
        /// Get a Task Item from the data base based on its id
        /// </summary>
        /// <param name="id">Task Item Id</param>
        /// <returns></returns>
        public async Task<TaskItemEntity> GetByIdAsync(int id)
        {
            return await _dbContext.TaskItems.FindAsync(id)
                ?? throw new KeyNotFoundException(string.Format("Task with id={0} not found", id));
        }

        /// <summary>
        /// Update the status value of a task item based on its id
        /// </summary>
        /// <param name="id">Task item id</param>
        /// <param name="newStatus">New task item status</param>
        /// <returns></returns>
        public async Task UpdateStatusByIdAsync(int id, string newStatus)
        {
            var taskItem = await GetByIdAsync(id);
            taskItem.TaskStatus = newStatus;

            await _dbContext.SaveChangesAsync();
        }
    }
}
