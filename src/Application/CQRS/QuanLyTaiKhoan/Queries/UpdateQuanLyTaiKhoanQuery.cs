using Gconnect.Application.Common.Interfaces;
using Gconnect.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
public record UpdateQuanLyTaiKhoanQuery : IRequest
{
    public string id { get; set; } = null!;
    public string roleId { get; set; } = null!;
    public string roleIdUpdate { get; set; } = null!;

}
public class UpdateQuanLYTaiKhoanHandler : IRequestHandler<UpdateQuanLyTaiKhoanQuery>
{
    private readonly IApplicationDbContext _context;

    public UpdateQuanLYTaiKhoanHandler(IApplicationDbContext context)
    {

        _context = context;
    }
    public async Task<Unit> Handle(UpdateQuanLyTaiKhoanQuery request, CancellationToken cancellationToken)
    {

        var userRole = await _context.AspNetUserRoles.FirstOrDefaultAsync(x => x.UserId == request.id && x.RoleId == request.roleId);

        if (userRole == null)
        {
            var setRoleToUser = new AspNetUserRole
            {
                UserId = request.id,
                RoleId = request.roleIdUpdate
            };
            _context.AspNetUserRoles.Add(setRoleToUser);
            await _context.SaveChangesAsync(cancellationToken);
        }
        else
        {

            userRole.RoleId = request.roleIdUpdate;
            _context.AspNetUserRoles.Update(userRole);
            await _context.SaveChangesAsync(cancellationToken);

        }
        //entity.TinhTrangXuLyText = "Chưa xử lý";



        return Unit.Value;
    }
}
