using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Mappings;
using Gconnect.Application.Common.Models;
using Gconnect.Application.DTO;
using Gconnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gconnect.Infrastructure.Services;
public class QuanLyTaiKhoanService : IQuanLyTaiKhoan
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public QuanLyTaiKhoanService(
        IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<string> Create(TaiKhoanViewModel user)
    {
        var obj = _mapper.Map<AspNetUser>(user.User);
        obj.Id = Guid.NewGuid().ToString();
        _context.AspNetUsers.Add(obj);

        foreach (var role in user.Roles)
        {
            UserRoleDTO roleUserDTO = new UserRoleDTO
            {
                Id = Guid.NewGuid().ToString(),
                UserId = obj.Id,
                RoleId = role
            };

            var roleUserModel = _mapper.Map<AspNetUserRole>(roleUserDTO);
            _context.AspNetUserRoles.Add(roleUserModel);
        }

        await _context.SaveChangesAsync(new CancellationToken());
        return obj.Id;
    }

    public async Task<int> DeleteUser(string userId)
    {
        var user = _context.AspNetUsers.FirstOrDefault(c => c.Id == userId);
        if (user != null)
        {
            _context.AspNetUsers.Remove(user);
        }
        var userRoles = _context.AspNetUserRoles.Where(x => x.UserId.Equals(userId));
        if (userRoles.Any()) _context.AspNetUserRoles.RemoveRange(userRoles);

        return await _context.SaveChangesAsync(new CancellationToken());
    }

    public async Task<PaginatedList<UserDTO>> getAllPaging(string keySearch, int pageNumber, int pageSize)
    {
        var query = _context.AspNetUsers.AsNoTracking();
        if (!string.IsNullOrEmpty(keySearch))
        {
            query = query.Where(c => c.UserName.Contains(keySearch));
        }
        var objs = await query.ProjectTo<UserDTO>(_mapper.ConfigurationProvider).PaginatedListAsync(pageNumber, pageSize);
        return objs;
    }

    public async Task<TaiKhoanViewModel> GetById(string userId)
    {
        var user = await _context.AspNetUsers.SingleOrDefaultAsync(c => c.Id == userId);

        //var roles = await _context.AspNetUserRoles.Where(x => x.UserId.Equals(userId)).ToListAsync();
        var roles = await (from r in _context.AspNetRoles
                           join ru in _context.AspNetUserRoles
                           on r.Id equals ru.RoleId
                           join u in _context.AspNetUsers
                           on ru.UserId equals u.Id
                           where u.Id == userId
                           select r.Id).Distinct().ToListAsync();


        TaiKhoanViewModel taiKhoanViewModel = new TaiKhoanViewModel
        {
            User = _mapper.Map<UserDTO>(user),
            Roles = roles
        };


        if (taiKhoanViewModel != null)
        {
            return taiKhoanViewModel;
        }
        return null;
    }

    public async Task<string> Update(TaiKhoanViewModel user)
    {
        //sua  user
        var obj = _mapper.Map<AspNetUser>(user.User);
        _context.AspNetUsers.Update(obj);

        // xoa role cu
        var userRolesCurrent = await _context.AspNetUserRoles.Where(x => x.UserId == obj.Id).ToListAsync();

        if (userRolesCurrent.Any()) _context.AspNetUserRoles.RemoveRange(userRolesCurrent);

        // them lai role
        foreach (var role in user.Roles)
        {
            UserRoleDTO roleDTO = new UserRoleDTO
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.User.Id,
                RoleId = role
            };
            var roleModel = _mapper.Map<AspNetUserRole>(roleDTO);
            await _context.AspNetUserRoles.AddAsync(roleModel);
        }
        await _context.SaveChangesAsync(new CancellationToken());
        return obj.Id;
    }
}
