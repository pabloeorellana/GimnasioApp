using GimnasioApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GimnasioApp.Core.Interfaces
{
    public interface ISocioRepository
    {
        Task<Socio> GetByIdAsync(int id);
        Task<IEnumerable<Socio>> GetAllAsync();
        Task AddAsync(Socio socio);
        Task UpdateAsync(Socio socio);
        Task DeleteAsync(int id);
    }
}