using AutoMapper;
using Data.DTOs;
using Data.Models;

namespace Configurations
{
    class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Patient, CreatePatientDTO>().ReverseMap();
            CreateMap<RadOrder, RadOrderDTO>().ReverseMap();
            CreateMap<RadOrder, CreatePatientDTO>().ReverseMap();

            CreateMap<ApiUser, UserDTO>().ReverseMap();

        }

    }
}