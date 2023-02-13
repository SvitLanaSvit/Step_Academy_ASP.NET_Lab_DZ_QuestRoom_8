using AutoMapper;
using Lab_DZ_KvestRoom_8.Data;
using Lab_DZ_KvestRoom_8.Models.DTO;

namespace Lab_DZ_KvestRoom_8.AutoMapperProfiles
{
    public class QuestRoomProfile : Profile
    {
        public QuestRoomProfile() 
        { 
            CreateMap<QuestRoom, QuestRoomDTO>().ReverseMap();
        }
    }
}