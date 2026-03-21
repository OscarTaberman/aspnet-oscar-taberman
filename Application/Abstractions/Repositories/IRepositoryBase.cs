namespace Application.Abstractions.Repositories;

public interface IRepositoryBase<TModel, TId>
{
    Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TModel>> GetAllAsync(CancellationToken ct = default);
    Task<TModel?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<TModel> UpdateAsync(TId id, TModel model, CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(TId id, CancellationToken cancellationToken = default);
}
