using ProductosAPI.Domain.Entities;
using ProductosAPI.Domain.Repositories;

namespace ProductosAPI.Application.Services
{
    public class MaquinaService
    {
        private readonly IMaquinaRepository _productoRepository;

        public MaquinaService(IMaquinaRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Maquina>> ObtenerTodos()
        {
            return await _productoRepository.GetAllAsync();
        }

        public async Task<Maquina?> ObtenerPorId(Guid id)
        {
            return await _productoRepository.GetByIdAsync(id);
        }

        public async Task Agregar(Maquina producto)
        {
            await _productoRepository.AddAsync(producto);
        }

        public async Task Actualizar(Maquina producto)
        {
            await _productoRepository.UpdateAsync(producto);
        }

        public async Task Eliminar(Guid id)
        {
            await _productoRepository.DeleteAsync(id);
        }
    }
}
