namespace Application
{
    public class DeleteTaskItemUseCase<T>
    {
        private readonly IRepository<T> _repository;

        public DeleteTaskItemUseCase(IRepository<T> repository) => _repository = repository;

        public async Task ExecuteAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}
