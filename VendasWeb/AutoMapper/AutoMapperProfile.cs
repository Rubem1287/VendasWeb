using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VendasWeb.Models;
using VendasWeb.Models.ViewModels;

namespace VendasWeb.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vendedor, VendedorFormViewModel>().ReverseMap();
            
          
        }
    }
}
