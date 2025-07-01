using AutoMapper;
using GimnasioApp.Core.Entities;
using GimnasioApp.Application.DTOs;
using System;

namespace GimnasioApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Socio, SocioDTO>()
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.Nombre} {src.Apellido}"));
            CreateMap<SocioDTO, SocioUpdateDTO>();
            CreateMap<SocioCreateDTO, Socio>().ReverseMap();
            CreateMap<SocioUpdateDTO, Socio>().ReverseMap();

            
            CreateMap<Clase, ClaseDTO>()
                
                .ForMember(dest => dest.Horario, opt => opt.MapFrom(src => $"{src.HoraInicio.ToString(@"hh\:mm")} - {src.HoraFin.ToString(@"hh\:mm")}"));
            CreateMap<ClaseDTO, ClaseUpdateDTO>();
            CreateMap<ClaseCreateDTO, Clase>().ReverseMap();
            CreateMap<ClaseUpdateDTO, Clase>().ReverseMap();
        }
    }
}