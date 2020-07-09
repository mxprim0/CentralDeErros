using AutoMapper;
using CentralDeErros.Api.DTOs;
using CentralDeErros.Api.Models;

namespace CentralDeErros.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Environment, EnvironmentDTO>().ReverseMap();
            CreateMap<Error, ErrorDTO>().ReverseMap();
            CreateMap<ErrorOccurrence, ErrorOccurrenceDTO>().ReverseMap();
            CreateMap<Level, LevelDTO>().ReverseMap();
            CreateMap<Situation, SituationDTO>().ReverseMap();
            CreateMap<Users, UserDTO>().ReverseMap();
        }
    }
}