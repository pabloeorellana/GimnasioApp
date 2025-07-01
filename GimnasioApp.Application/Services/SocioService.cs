using AutoMapper;
using GimnasioApp.Application.DTOs;
using GimnasioApp.Core.Entities;
using GimnasioApp.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GimnasioApp.Application.Services
{
    public class SocioService : ISocioService
    {
        private readonly ISocioRepository _socioRepository;
        private readonly IMapper _mapper;

        public SocioService(ISocioRepository socioRepository, IMapper mapper)
        {
            _socioRepository = socioRepository;
            _mapper = mapper;
        }

        public async Task<SocioDTO> CreateSocioAsync(SocioCreateDTO socioDto)
        {
            var socio = _mapper.Map<Socio>(socioDto);
            socio.FechaInscripcion = System.DateTime.Now; // Se asigna la fecha de inscripción
            await _socioRepository.AddAsync(socio);
            return _mapper.Map<SocioDTO>(socio);
        }

        public async Task DeleteSocioAsync(int id)
        {
            await _socioRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SocioDTO>> GetAllSociosAsync()
        {
            var socios = await _socioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SocioDTO>>(socios);
        }

        public async Task<SocioDTO> GetSocioByIdAsync(int id)
        {
            var socio = await _socioRepository.GetByIdAsync(id);
            return _mapper.Map<SocioDTO>(socio);
        }

        public async Task UpdateSocioAsync(SocioUpdateDTO socioDto)
        {
            var socioExistente = await _socioRepository.GetByIdAsync(socioDto.Id);
            if (socioExistente == null)
            {
                // Podrías lanzar una excepción o manejar este caso según tu lógica de negocio
                throw new KeyNotFoundException($"Socio con ID {socioDto.Id} no encontrado.");
            }

            _mapper.Map(socioDto, socioExistente); // Mapea los valores del DTO a la entidad existente
            await _socioRepository.UpdateAsync(socioExistente);
        }
    }
}