using System.Linq.Dynamic.Core;
using AutoMapper;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Models;
using Gconnect.Domain.Entities;
using MediatR;

namespace Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
public record GetDetailTaiKhoan : IRequest<GetDetailTaiKhoanVm>
{

    public string? Id { get; set; } = string.Empty;

}
public class GetDetailTaiKhoanVm : BaseViewModel<IQueryable<AspNetUser>>
{

}
public class GetDetailTaiKhoanHandler : IRequestHandler<GetDetailTaiKhoan, GetDetailTaiKhoanVm>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;
    public GetDetailTaiKhoanHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<GetDetailTaiKhoanVm> Handle(GetDetailTaiKhoan request, CancellationToken cancellationToken)
    {
        var result = new GetDetailTaiKhoanVm();


        var query = from user in _context.AspNetUsers
                     where user.Id == request.Id
                     select user


                      ;
        result.Result = query;


        // string uid = "8f4bcece-7402-4e86-8f6f-42496fa13459";
        //var user = _context.AspNetUsers.FirstOrDefault(c => c.Id == uid);
        //var userrole = _context.AspNetUserRoles.Where(c => c.UserId == request.Id).ToList();
        //var role = userrole.FirstOrDefault() != null ? userrole.FirstOrDefault().Role : null;
        // end demo

        return result;

    }

}