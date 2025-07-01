using GimnasioApp.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GimnasioApp.Application.Services
{
    public interface ISocioService
    {
        Task<IEnumerable<SocioDTO>> GetAllSociosAsync();
        Task<SocioDTO> GetSocioByIdAsync(int id);
        Task<SocioDTO> CreateSocioAsync(SocioCreateDTO socioDto);
        Task UpdateSocioAsync(SocioUpdateDTO socioDto);
        Task DeleteSocioAsync(int id);
    }
}