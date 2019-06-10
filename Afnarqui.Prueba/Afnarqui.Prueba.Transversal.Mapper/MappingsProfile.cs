using System;
using AutoMapper;
using Afnarqui.Prueba.Domain.Entity;
using Afnarqui.Prueba.Aplication.DTO;

namespace Afnarqui.Prueba.Transversal.Mapper
{
    public class MappingsProfile: Profile
    {
        public MappingsProfile()
        {
            CreateMap<Persons, PersonsDto>().ReverseMap()
                .ForMember(destination => destination.personsId, source => source.MapFrom(src => src.personsId))
                .ForMember(destination => destination.identity, source => source.MapFrom(src => src.identity))
                .ForMember(destination => destination.password, source => source.MapFrom(src => src.password))
                .ReverseMap();
        }
    }
}
