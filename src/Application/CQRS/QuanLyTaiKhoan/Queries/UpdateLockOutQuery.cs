using Gconnect.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
public record UpdateLockOutQuery : IRequest
{
    public string id { get; set; } = null!;
    public bool LockState { get; set; } = true;

}
public class UpdateLockOutQueryHandler : IRequestHandler<UpdateLockOutQuery>
{
    private readonly IApplicationDbContext _context;

    public UpdateLockOutQueryHandler(IApplicationDbContext context)
    {

        _context = context;
    }
    public async Task<Unit> Handle(UpdateLockOutQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.AspNetUsers.FirstOrDefaultAsync(x => x.Id == request.id);
        user.LockoutEnabled = request.LockState;
        _context.AspNetUsers.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
        //entity.TinhTrangXuLyText = "Chưa xử lý";

        return Unit.Value;
    }
}
