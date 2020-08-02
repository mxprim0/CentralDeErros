using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CentralDeErros.API.Dto;
using CentralDeErros.API.Models;
using CentralDeErros.Infra.Entidades;

namespace CentralDeErros.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Environment, EnvironmentDTO>().ReverseMap();
            CreateMap<Error, ErrorDTO>().ReverseMap();
            CreateMap<Level, LevelDTO>().ReverseMap();
            CreateMap<Logs, LogsDTO>().ReverseMap();
            CreateMap<Situation, SituatonDTO>().ReverseMap();
            CreateMap<Users, UsersDTO>().ReverseMap();

        }
    }
}
