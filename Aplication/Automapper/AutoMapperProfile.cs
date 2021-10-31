using Aplication.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Automapper
{
    public sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Autor, AutorDto>();
            CreateMap<AutorDto, Autor>();

            CreateMap<Libro, LibroDto>().ForMember(x => x.editorial, src => src.MapFrom(x => x.Editoriales.Id));
            CreateMap<LibroDto, Libro>().ForMember(x => x.EditorialesId, src => src.MapFrom(x => Convert.ToInt32(x.editorial)));

            CreateMap<AutoresHasLibro, AutoresHasLibroDto>();
            CreateMap<AutoresHasLibroDto, AutoresHasLibro>();

            CreateMap<Editorial, EditorialDto>();
            CreateMap<EditorialDto, Editorial>();
        }
    }
}
