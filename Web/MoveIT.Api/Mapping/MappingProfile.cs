using AutoMapper;

using MoveIT.Api.Dto;
using MoveIT.Core.Models;

namespace MoveIT.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovingProposalPrice, MovingProposalDto>()
                .ForMember(m => m.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(x => x.User.LastName))
                .ForMember(m => m.Email, opt => opt.MapFrom(x => x.User.Email));

            CreateMap<CreateMovingProposal, MovingProposal>()
                .ForMember(x => x.CreateDate, opt => opt.Ignore())
                .ForMember(x => x.LastUpdateDate, opt => opt.Ignore())
                .ForMember(m => m.User, opt => opt.Ignore());

            CreateMap<CreateOrder, Order>();
            CreateMap<Order, OrderDetails>();

            CreateMap<LoginUser, AuthenticatedUser>()
                .ForMember(u => u.Token, opt => opt.Ignore());

            CreateMap<RegisterUser, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(u => u.Email));
        }
    }
}
