using GimnasioApp.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GimnasioApp.Application.Services
{
    public interface IClaseService
    {
        Task<IEnumerable<ClaseDTO>> GetAllClasesAsync();
        Task<ClaseDTO> GetClaseByIdAsync(int id);
        Task<ClaseDTO> CreateClaseAsync(ClaseCreateDTO claseDto);
        Task UpdateClaseAsync(ClaseUpdateDTO claseDto);
        Task DeleteClaseAsync(int id);
    }
}