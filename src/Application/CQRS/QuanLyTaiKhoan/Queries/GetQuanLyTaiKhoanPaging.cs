using System.Linq.Expressions;
using AutoMapper;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Mappings;
using Gconnect.Application.Common.Models;
using Gconnect.Domain.Entities;
using MediatR;

namespace Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
public record GetQuanLyTaiKhoanPaging : IRequest<GetQuanLyTaiKhoanPagingVm>
{

    public string? KeySearch { get; set; } = string.Empty;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string SortExpression { get; set; } = "UserName asc";


    public List<Expression<Func<AspNetUser, bool>>> GetPredicates()
    {
        var filter = new List<Expression<Func<AspNetUser, bool>>>();
        if (!string.IsNullOrEmpty(KeySearch))
        {
            filter.Add(c => c.UserName.ToLower().Contains(KeySearch.ToLower()) || c.Email.ToLower().Contains(KeySearch.ToLower()) || c.PhoneNumber.ToLower().Contains(KeySearch.ToLower()));
        }

        return filter;
    }


}
public class GetQuanLyTaiKhoanPagingVm : BaseViewModel<PaginatedList<AspNetUser>>
{

}
public class GetQuanLyTaiKhoanPagingHandler : IRequestHandler<GetQuanLyTaiKhoanPaging, GetQuanLyTaiKhoanPagingVm>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;
    public GetQuanLyTaiKhoanPagingHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<GetQuanLyTaiKhoanPagingVm> Handle(GetQuanLyTaiKhoanPaging request, CancellationToken cancellationToken)
    {
        var predicate = request.GetPredicates();
        var vm = new GetQuanLyTaiKhoanPagingVm();
        var u = _context.AspNetUsers.ToList();
        //vm.Result = await _context.AspNetUsers.AsNoTracking().
        //                                            WhereMany(predicate.ToArray()).
        //                                            OrderBy(request.SortExpression).

        //                                            PaginatedListAsync(request.PageNumber, request.PageSize);

        vm.Result = await _context.AspNetUsers.PaginatedListAsync(request.PageNumber, request.PageSize);
        //var query = from user in _context.AspNetUsers
        //            join role in _context.AspNetRoles on user.Id equals role.Id
        //            where (!string.IsNullOrEmpty(request.KeySearch))
        //            select new QuanLyTaiKhoanDTO
        //            {
        //                Roles = role.Name,

        //            };

        //var query = from user in _context.AspNetUsers
        //            where user.Roles.All(role=>)

        //            select user;

        //query = query.OrderBy(request.SortExpression);
        //var count = query.Count();
        //var items = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        //vm.Result = new PaginatedList<AspNetUser>(items, count, request.PageNumber, request.PageSize);


        return vm;
    }

}