using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Layer.Architecture.Domain.ViewModel.Rota;


namespace Layer.Architeture.Configuracao
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateRotaVM, Rota>().ReverseMap();
            CreateMap<RotaVM, Rota>().ReverseMap();
            
        }
    }
}
