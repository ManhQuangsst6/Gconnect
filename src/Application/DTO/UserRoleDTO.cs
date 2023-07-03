using AutoMapper;
using Gconnect.Application.Common.Mappings;
using Gconnect.Domain.Entities;

namespace Gconnect.Application.DTO;
public class UserRoleDTO : IMapFrom<AspNetUserRole>
{
    public string Id { get; set; }
    public string UserId { get; set; } = null!;

    public string RoleId { get; set; } = null!;


    public void Mapping(Profile profile)
    {
        profile.CreateMap<AspNetUserRole, UserRoleDTO>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
            .ForMember(d => d.RoleId, opt => opt.MapFrom(s => s.RoleId));


        profile.CreateMap<UserRoleDTO, AspNetUserRole>()
           .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
           .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
           .ForMember(d => d.RoleId, opt => opt.MapFrom(s => s.RoleId));


    }
}
