using AutoMapper;
using Gconnect.Application.Common.Mappings;
using Gconnect.Domain.Entities;


namespace Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
public class QuanLyTaiKhoanDTO : IMapFrom<AspNetUser>
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

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; } = new List<AspNetUserToken>();

    public virtual ICollection<AspNetRole> Roles { get; } = new List<AspNetRole>();


    public void Mapping(Profile profile)
    {
        profile.CreateMap<AspNetUser, QuanLyTaiKhoanDTO>().
                ForMember(u => u.Id, opt => opt.MapFrom(s => s.Id)).
                ForMember(u => u.UserName, opt => opt.MapFrom(s => s.UserName)).
                ForMember(u => u.NormalizedUserName, opt => opt.MapFrom(s => s.NormalizedUserName)).
                ForMember(u => u.Email, opt => opt.MapFrom(s => s.Email)).
                ForMember(u => u.NormalizedEmail, opt => opt.MapFrom(s => s.NormalizedEmail)).
                ForMember(u => u.SecurityStamp, opt => opt.MapFrom(s => s.SecurityStamp)).
                ForMember(u => u.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber)).
                ForMember(u => u.PhoneNumberConfirmed, opt => opt.MapFrom(s => s.PhoneNumberConfirmed)).
                ForMember(u => u.LockoutEnd, opt => opt.MapFrom(s => s.LockoutEnd)).
                //ForMember(u => u.Roles, opt => opt.MapFrom(s => s.Roles)).
                ForMember(u => u.AspNetUserClaims, opt => opt.MapFrom(s => s.AspNetUserClaims)).
                ForMember(u => u.AspNetUserLogins, opt => opt.MapFrom(s => s.AspNetUserLogins)).
                ForMember(u => u.AspNetUserTokens, opt => opt.MapFrom(s => s.AspNetUserTokens));


    }

    //public static implicit operator QuanLyTaiKhoanDTO?(ThongTinPhanHoiDTO? v)
    //{
    //    throw new NotImplementedException();
    //}
}
