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
            //CreateMap<Note, ExportDto>().ForMember(dto => dto.Notes, opt => opt.MapFrom(x => x.Text));
            CreateMap<Policy, ExportDto>().ForMember(
                dto => dto.Notes,
                opt => opt.MapFrom(x => x.Notes.Select(x => x.Text)));

        }
    }
}
