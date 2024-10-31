using ProductosAPI.Domain.Entities;
using ProductosAPI.Domain.Repositories;
using ProductosAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductosAPI.Infrastructure.Repositories
{
    public class MaquinaRepository : IMaquinaRepository
    {
        private readonly ApplicationDbContext _context;

        public MaquinaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Maquina>> GetAllAsync() => await _context.Maquinas.ToListAsync();

        public async Task<Maquina?> GetByIdAsync(Guid id) => await _context.Maquinas.FindAsync(id);

        public async Task AddAsync(Maquina maquina)
        {
            await _context.Maquinas.AddAsync(maquina);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Maquina maquina)
        {
            _context.Maquinas.Update(maquina);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var maquina = await GetByIdAsync(id);
            if (maquina != null)
            {
                _context.Maquinas.Remove(maquina);
                await _context.SaveChangesAsync();
            }
        }
    }
}
