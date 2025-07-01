using AutoMapper;
using GimnasioApp.Application.DTOs;
using GimnasioApp.Core.Entities;
using GimnasioApp.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GimnasioApp.Application.Services
{
    public class ClaseService : IClaseService
    {
        private readonly IClaseRepository _claseRepository;
        private readonly IMapper _mapper;

        public ClaseService(IClaseRepository claseRepository, IMapper mapper)
        {
            _claseRepository = claseRepository;
            _mapper = mapper;
        }

        public async Task<ClaseDTO> CreateClaseAsync(ClaseCreateDTO claseDto)
        {
            var clase = _mapper.Map<Clase>(claseDto);
            await _claseRepository.AddAsync(clase);
            return _mapper.Map<ClaseDTO>(clase);
        }

        public async Task DeleteClaseAsync(int id)
        {
            await _claseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ClaseDTO>> GetAllClasesAsync()
        {
            var clases = await _claseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClaseDTO>>(clases);
        }

        public async Task<ClaseDTO> GetClaseByIdAsync(int id)
        {
            var clase = await _claseRepository.GetByIdAsync(id);
            return _mapper.Map<ClaseDTO>(clase);
        }

        public async Task UpdateClaseAsync(ClaseUpdateDTO claseDto)
        {
            var claseExistente = await _claseRepository.GetByIdAsync(claseDto.Id);
            if (claseExistente == null)
            {
                throw new KeyNotFoundException($"Clase con ID {claseDto.Id} no encontrada.");
            }

            _mapper.Map(claseDto, claseExistente);
            await _claseRepository.UpdateAsync(claseExistente);
        }
    }
}