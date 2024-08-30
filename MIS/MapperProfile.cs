using AutoMapper;
using MIS.Domains;
using MIS.DTO;
using MIS.Models;

namespace MIS
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Student, StudentModel>();
            CreateMap<StudentDto, Student>();
        }
       
    }
}
