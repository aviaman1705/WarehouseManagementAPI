using AutoMapper;
using MvcTaskManager.Models;
using MvcTaskManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTaskManager
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Dashboard, DashboardDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Location, LocationDTO>();
        }
    }
}
