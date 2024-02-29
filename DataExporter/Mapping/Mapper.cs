using AutoMapper;
using DataExporter.Dtos;
using DataExporter.Model;

namespace DataExporter.Mapping
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Policy, ReadPolicyDto>().ReverseMap();
            CreateMap<Policy, CreatePolicyDto>().ReverseMap();
        }
    }
}
