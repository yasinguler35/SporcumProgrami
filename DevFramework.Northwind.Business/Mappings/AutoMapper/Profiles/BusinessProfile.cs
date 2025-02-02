﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Product, Product>();
            CreateMap<Sporcu, Sporcu>();
            CreateMap<SporcuFoto, SporcuFoto>();
            CreateMap<SporcuKategori, SporcuKategori>();
            //Sporcu ödemeleri mapping
            CreateMap<SporcuOdemeleri,SporcuOdemeleri>();
            CreateMap<KusakOdemeleri, KusakOdemeleri>();
            CreateMap<Kusaklar, Kusaklar>();
            CreateMap<TesisFaturam, TesisFaturam>();
        }
    }
}
