using AutoMapper;
using Gconnect.Application.Common.Mappings;
using Gconnect.Domain.Entities;

namespace Gconnect.Application.DTO;
public class UserDTO : IMapFrom<AspNetUser>
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<RoleDto> Roles { get; set; } = new List<RoleDto>();


    public void Mapping(Profile profile)
    {
        profile.CreateMap<AspNetUser, UserDTO>().
                ForMember(u => u.Id, opt => opt.MapFrom(s => s.Id)).
                ForMember(u => u.UserName, opt => opt.MapFrom(s => s.UserName)).
                ForMember(u => u.NormalizedUserName, opt => opt.MapFrom(s => s.NormalizedUserName)).
                ForMember(u => u.Email, opt => opt.MapFrom(s => s.Email)).
                ForMember(u => u.NormalizedEmail, opt => opt.MapFrom(s => s.NormalizedEmail)).
                ForMember(u => u.SecurityStamp, opt => opt.MapFrom(s => s.SecurityStamp)).
                ForMember(u => u.ConcurrencyStamp, opt => opt.MapFrom(s => s.ConcurrencyStamp)).
                ForMember(u => u.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber)).
                ForMember(u => u.PhoneNumberConfirmed, opt => opt.MapFrom(s => s.PhoneNumberConfirmed)).
                ForMember(u => u.LockoutEnd, opt => opt.MapFrom(s => s.LockoutEnd));

        profile.CreateMap<UserDTO, AspNetUser>().
                ForMember(u => u.Id, opt => opt.MapFrom(s => s.Id)).
                ForMember(u => u.UserName, opt => opt.MapFrom(s => s.UserName)).
                ForMember(u => u.NormalizedUserName, opt => opt.MapFrom(s => s.NormalizedUserName)).
                ForMember(u => u.Email, opt => opt.MapFrom(s => s.Email)).
                ForMember(u => u.NormalizedEmail, opt => opt.MapFrom(s => s.NormalizedEmail)).
                ForMember(u => u.SecurityStamp, opt => opt.MapFrom(s => s.SecurityStamp)).
                ForMember(u => u.ConcurrencyStamp, opt => opt.MapFrom(s => s.ConcurrencyStamp)).
                ForMember(u => u.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber)).
                ForMember(u => u.PhoneNumberConfirmed, opt => opt.MapFrom(s => s.PhoneNumberConfirmed)).
                ForMember(u => u.LockoutEnd, opt => opt.MapFrom(s => s.LockoutEnd));
    }
}
