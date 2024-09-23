namespace Application
{
    public class GetAllUseCase<T>
    {
        private readonly IRepository<T> _repository;

        public GetAllUseCase(IRepository<T> repository) => _repository = repository;

        public async Task<IEnumerable<T>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
