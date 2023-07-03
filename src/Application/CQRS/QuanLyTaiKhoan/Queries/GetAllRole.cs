using System.Linq.Dynamic.Core;
using AutoMapper;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Models;
using Gconnect.Domain.Entities;
using MediatR;

namespace Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
public record GetAllRole : IRequest<GetAllRoleVm>
{
    public string userId { get; set; } = null!;
}
public class GetAllRoleVm : BaseViewModel<List<AspNetRole>>
{
}

public class GetAllRoleHandler : IRequestHandler<GetAllRole, GetAllRoleVm>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;
    public GetAllRoleHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<GetAllRoleVm> Handle(GetAllRole request, CancellationToken cancellationToken)
    {
        var result = new GetAllRoleVm();


        var userRoles = _context.AspNetUserRoles
                        .Where(ur => ur.UserId == request.userId)
                        .Select(ur => ur.RoleId)
                        .ToList();

        // Lấy danh sách các role mà user chưa có
        var missingRoles = _context.AspNetRoles
                                  .Where(r => !userRoles.Contains(r.Id))
                                  .ToList();
        result.Result = missingRoles;

        return result;
    }

}