using AutoMapper;
using Gconnect.Application.Common.Mappings;
using Gconnect.Domain.Entities;

namespace Gconnect.Application.DTO;
public class AspNetUserRoleDTO : IMapFrom<AspNetUserRole>
{
    public string Id { get; set; }
    public string UserId { get; set; } = null!;

    public string RoleId { get; set; } = null!;


    public void Mapping(Profile profile)
    {
        profile.CreateMap<AspNetUserRole, AspNetUserRoleDTO>().
                ForMember(u => u.Id, opt => opt.MapFrom(s => s.Id)).
                ForMember(u => u.UserId, opt => opt.MapFrom(s => s.UserId)).
                ForMember(u => u.RoleId, opt => opt.MapFrom(s => s.RoleId));

        profile.CreateMap<AspNetUserRoleDTO, AspNetUserRole>().
               ForMember(u => u.Id, opt => opt.MapFrom(s => s.Id)).
                ForMember(u => u.UserId, opt => opt.MapFrom(s => s.UserId)).
                ForMember(u => u.RoleId, opt => opt.MapFrom(s => s.RoleId));
    }
}
