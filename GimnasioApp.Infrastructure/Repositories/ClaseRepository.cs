using GimnasioApp.Core.Entities;
using GimnasioApp.Core.Interfaces;
using GimnasioApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GimnasioApp.Infrastructure.Repositories
{
    public class ClaseRepository : IClaseRepository
    {
        private readonly GimnasioDbContext _context;

        public ClaseRepository(GimnasioDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Clase clase)
        {
            await _context.Clases.AddAsync(clase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var clase = await _context.Clases.FindAsync(id);
            if (clase != null)
            {
                _context.Clases.Remove(clase);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Clase>> GetAllAsync()
        {
            return await _context.Clases.ToListAsync();
        }

        public async Task<Clase> GetByIdAsync(int id)
        {
            return await _context.Clases.FindAsync(id);
        }

        public async Task UpdateAsync(Clase clase)
        {
            _context.Clases.Update(clase);
            await _context.SaveChangesAsync();
        }
    }
}