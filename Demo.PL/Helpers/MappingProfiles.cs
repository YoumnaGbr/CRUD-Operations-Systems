using AutoMapper;
using Demo.DAL.Data.Migrations;
using Demo.DAL.Models;
using Demo.PL.ViewModels;

namespace Demo.PL.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeViewModel, Employee>()
                .ReverseMap();
        }
    }
}
