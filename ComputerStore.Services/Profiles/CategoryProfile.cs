using AutoMapper;
using ComputerStore.Services.DTOs;
using ComputerStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ComputerStore.Services.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
