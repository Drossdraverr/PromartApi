using AutoMapper;
using PromartApi.Dto;
using PromartApi.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromartApi.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Clientes, ClienteDto>().ReverseMap();
            CreateMap<ClienteCreationDto, Clientes>();
        }
    }
}
