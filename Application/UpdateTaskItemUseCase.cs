namespace Application
{
    public class UpdateTaskItemUseCase<T>
    {
        private readonly IRepository<T> _repository;

        public UpdateTaskItemUseCase(IRepository<T> repository) => _repository = repository;

        public async Task ExecuteAsync(int id, string newStatus)
        {
            await _repository.UpdateStatusByIdAsync(id, newStatus);
        }
    }
}
