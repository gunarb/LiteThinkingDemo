using Domain;

namespace Application
{
    public interface IRepository<T>
    {
        Task AddTaskItemAsync(TaskItemEntity taskItemEntity);
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateStatusByIdAsync(int id, string newStatus);
        
    }
}
