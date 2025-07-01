using GimnasioApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GimnasioApp.Core.Interfaces
{
    public interface IClaseRepository
    {
        Task<Clase> GetByIdAsync(int id);
        Task<IEnumerable<Clase>> GetAllAsync();
        Task AddAsync(Clase clase);
        Task UpdateAsync(Clase clase);
        Task DeleteAsync(int id);
    }
}