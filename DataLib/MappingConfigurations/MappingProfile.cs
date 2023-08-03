using AutoMapper;
using DataLib.Models;

namespace DataLib.MappingConfigurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Default mapping when property names are same
            CreateMap<Item, ItemMini>();
            CreateMap<Item, ItemForAdd>().ReverseMap();
            CreateMap<Item, ItemForUpdate>().ReverseMap();
			
			CreateMap<User, UserForRead>().ReverseMap();			
			CreateMap<User, UserForAdd>().ReverseMap();			
			CreateMap<User, UserForUpdate>().ReverseMap();			
			CreateMap<UserForRead, UserForUpdate>().ReverseMap();
			CreateMap<UserForRead, UserForAdd>().ReverseMap();			


            // Mapping when property names are different
            //CreateMap<User, UserViewModel>()
            //    .ForMember(dest =>
            //    dest.FName,
            //    opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest =>
            //    dest.LName,
            //    opt => opt.MapFrom(src => src.LastName));
        }
    }
}
