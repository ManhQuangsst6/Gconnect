using System.Linq.Dynamic.Core;
using AutoMapper;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Models;
using Gconnect.Domain.Entities;
using MediatR;

namespace Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
public record GetRoleByUser : IRequest<GetRoleByUserVm>
{

    public string? Id { get; set; } = string.Empty;

}
public class GetRoleByUserVm : BaseViewModel<IQueryable<AspNetRole>>
{

}
public class GetRoleByUserVmHandler : IRequestHandler<GetRoleByUser, GetRoleByUserVm>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;
    public GetRoleByUserVmHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<GetRoleByUserVm> Handle(GetRoleByUser request, CancellationToken cancellationToken)
    {
        var result = new GetRoleByUserVm();


        var query = from user in _context.AspNetUsers
                     join userRole in _context.AspNetUserRoles on user.Id equals userRole.UserId
                     join role in _context.AspNetRoles on userRole.RoleId equals role.Id
                     where user.Id == request.Id
                     select role
                      ;
        result.Result = query;
        //var role = userrole.FirstOrDefault() != null ? userrole.FirstOrDefault().Role : null;
        // end demo

        return result;

    }

}