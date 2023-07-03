using AutoMapper;
using Gconnect.Application.Common.Mappings;
using Gconnect.Domain.Entities;

namespace Gconnect.Application.DTO;
public class DMPhongDTO : IMapFrom<DmPhong>
{
    public string Id { get; set; } = null!;
    public string? TenPhong { get; set; }
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    //  public string? LastModifiedBy { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DmPhong, DMPhongDTO>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.TenPhong, opt => opt.MapFrom(s => s.TenPhong))
            .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(s => s.CreatedBy))
            .ForMember(d => d.LastModified, opt => opt.MapFrom(s => s.LastModified));
        //   .ForMember(d => d.LastModifiedBy, opt => opt.MapFrom(s => s.LastModifiedBy));
        profile.CreateMap<DMPhongDTO, DmPhong>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.TenPhong, opt => opt.MapFrom(s => s.TenPhong))
            .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
            .ForMember(d => d.CreatedBy, opt => opt.MapFrom(s => s.CreatedBy))
            .ForMember(d => d.LastModified, opt => opt.MapFrom(s => s.LastModified));
        //   .ForMember(d => d.LastModifiedBy, opt => opt.MapFrom(s => s.LastModifiedBy));

    }
}
