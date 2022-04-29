using AutoMapper;
using CRUD_WEB_API.DTO;

namespace CRUD_WEB_API
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>()
                    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                    .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                    .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName));
            CreateMap<User, UserDTO>();

            CreateMap<User, AuthenticateResponse>()
                    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dst => dst.Token, opt => opt.Ignore());

            CreateMap<MeetUp, MeetUpDTO>()
                    .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
                    .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.Location))
                    .ForMember(dst => dst.Tags, opt => opt.MapFrom(src => src.Tags));

            CreateMap<MeetUpDTO, MeetUp>()
                    .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
                    .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.Location))
                    .ForMember(dst => dst.Tags, opt => opt.MapFrom(src => src.Tags));

            CreateMap<MeetUp, MeetUp>()
                    .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
                    .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.Location))
                    .ForMember(dst => dst.Tags, opt => opt.MapFrom(src => src.Tags));
        }
    }
}
