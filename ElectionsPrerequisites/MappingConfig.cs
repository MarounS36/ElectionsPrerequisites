using AutoMapper;
using ElectionsPrerequisites.Models.Dto;

namespace ElectionsPrerequisites
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            

            CreateMap<ElectionDTO, ElectionCreateDTO>().ReverseMap();
            CreateMap<ElectionDTO, ElectionUpdateDTO>().ReverseMap();
        }
        
    }
}
