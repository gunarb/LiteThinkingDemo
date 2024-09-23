namespace Application
{
    public class GetByIdUseCase<T>
    {
        private readonly IRepository<T> _repository;

        public GetByIdUseCase(IRepository<T> repository) => _repository = repository;

        public async Task<T> ExecuteAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
