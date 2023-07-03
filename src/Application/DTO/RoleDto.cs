using AutoMapper;
using Gconnect.Application.Common.Mappings;
using Gconnect.Domain.Entities;

namespace Gconnect.Application.DTO;
public class RoleDto : IMapFrom<AspNetRole>
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }
    public string? Description { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AspNetRole, RoleDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));

        profile.CreateMap<RoleDto, AspNetRole>()
           .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
           .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
           .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
           .ForMember(d => d.NormalizedName, opt => opt.MapFrom(s => s.Name == null ? null : s.Name.ToUpper()));
    }
}
