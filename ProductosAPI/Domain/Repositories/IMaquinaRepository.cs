using ProductosAPI.Domain.Entities;

namespace ProductosAPI.Domain.Repositories
{
    public interface IMaquinaRepository
    {
        Task<IEnumerable<Maquina>> GetAllAsync();
        Task<Maquina?> GetByIdAsync(Guid id);
        Task AddAsync(Maquina producto);
        Task UpdateAsync(Maquina producto);
        Task DeleteAsync(Guid id);
    }
}
