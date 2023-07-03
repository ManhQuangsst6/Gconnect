using AutoMapper;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Domain.Entities;
using MediatR;

namespace Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
public record CreateTaiKhoan : IRequest<string>
{

    public string Name { get; set; }
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}
public class CreateTaiKhoanHandler : IRequestHandler<CreateTaiKhoan, string>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;
    public CreateTaiKhoanHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<string> Handle(CreateTaiKhoan request, CancellationToken cancellationToken)
    {
        Guid guid = new Guid();


        var taikhoan = new AspNetUser
        {
            Id = guid.ToString("N"),
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            UserName = request.Name,
            PasswordHash = request.Password,
        };
        _context.AspNetUsers.Add(taikhoan);
        await _context.SaveChangesAsync(cancellationToken);
        return taikhoan.Id;

    }
}
