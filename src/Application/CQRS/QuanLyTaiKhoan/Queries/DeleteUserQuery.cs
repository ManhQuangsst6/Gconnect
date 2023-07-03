using AutoMapper;
using Gconnect.Application.Common.Exceptions;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Domain.Entities;
using MediatR;

namespace Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
public record DeleteUserQuery : IRequest
{
    public string Id { get; set; } = string.Empty;
}
public class DeleteUserHandler : IRequestHandler<DeleteUserQuery>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;
    public DeleteUserHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    public async Task<Unit> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.AspNetUsers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(AspNetUser), request.Id);
        }
        _context.AspNetUsers.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}