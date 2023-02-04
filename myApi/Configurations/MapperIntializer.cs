using AutoMapper;
using Data.DTOs;
using Data.Models;

namespace Configurations
{
    class MapperInitializer : Profile
    {
<<<<<<< HEAD
        // this is spartaaaaaaaa
=======
>>>>>>> 6987186885d413653d585ae11996e3980083b9ba
        public MapperInitializer()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Patient, CreatePatientDTO>().ReverseMap();
            CreateMap<RadOrder, RadOrderDTO>().ReverseMap();
            CreateMap<RadOrder, CreatePatientDTO>().ReverseMap();
        }

    }
}