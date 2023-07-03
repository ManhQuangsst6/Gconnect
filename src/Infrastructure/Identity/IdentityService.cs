using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Mappings;
using Gconnect.Application.Common.Models;
using Gconnect.Application.DTO;
using Gconnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gconnect.Infrastructure.Identity;

public class IdentityService : IIdentityService
{

    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public IdentityService(
        IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
    {
        _context = context;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<string> GetUserNameAsync(string userId)
    {
        if (userId == null) userId = _currentUserService.UserId;
        if (userId == null) return "anynomous";
        var user = await _context.AspNetUsers.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new AspNetUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = userName,
            Email = userName,
        };
        _context.AspNetUsers.Add(user);
        var result = await _context.SaveChangesAsync(new CancellationToken());

        return (Result.Success(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        //var user = _context.AspNetUsers.SingleOrDefault(u => u.Id == userId);

        //return user != null && user.Roles.Any(c => c.Name == role);
        return _context.AspNetUserRoles.Any(c => c.UserId == userId && c.RoleId == role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _context.AspNetUsers.SingleOrDefault(u => u.Id == userId);

        return user != null;
    }

    public async Task<Result> DeleteUserByUserNameAsync(string username)
    {
        var user = _context.AspNetUsers.SingleOrDefault(u => u.UserName == username);
        try
        {
            _context.AspNetUsers.Remove(user);
            await _context.SaveChangesAsync(new CancellationToken());
        }
        catch (Exception ex)
        {
            List<string> errors = new List<string>();
            errors.Add(ex.Message);
            Result.Failure(errors);
        }
        return Result.Success();
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _context.AspNetUsers.SingleOrDefault(u => u.Id == userId);

        try
        {
            _context.AspNetUsers.Remove(user);
        }
        catch (Exception ex)
        {
            List<string> errors = new List<string>();
            errors.Add(ex.Message);
            Result.Failure(errors);
        }
        return Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var userToDelete = _context.AspNetUsers.SingleOrDefault(u => u.Id == user.Id);
        _context.AspNetUsers.Remove(userToDelete);
        await _context.SaveChangesAsync(new CancellationToken());
        return Result.Success();
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

    public async Task<UserDTO?> GetById(string userId)
    {
        var user = await _context.AspNetUsers.SingleOrDefaultAsync(c => c.Id == userId);

        if (user != null)
        {
            return _mapper.Map<UserDTO>(user);
        }
        return null;
    }

    public List<RoleDto> GetRole(string userId)
    {
        var result = new List<RoleDto>();
        var roleOfUser = _context.AspNetUserRoles.Where(c => c.UserId == userId).Select(x => x.RoleId).ToList();
        if (roleOfUser.Any())
        {
            result.AddRange(_context.AspNetRoles.Where(c => roleOfUser.Contains(c.Id))
                .ProjectTo<RoleDto>(_mapper.ConfigurationProvider).ToList());
        }
        return result;
    }

    public async Task<int> UpdateRoleForUser(string userId, List<string> rolesIds)
    {
        // delete role cũ
        var oldRoles = _context.AspNetUserRoles.Where(c => c.UserId == userId).ToList();
        _context.AspNetUserRoles.RemoveRange(oldRoles);

        var newRoles = new List<AspNetUserRole>();
        var maxId = _context.AspNetUserRoles.Max(c => c.Id);
        foreach (var item in rolesIds)
        {
            var newId = maxId + 1; ;
            var userRole = new AspNetUserRole()
            {
                Id = newId,
                UserId = userId,
                RoleId = item,
            };
            newRoles.Add(userRole);
        }
        _context.AspNetUserRoles.AddRange(newRoles);
        return await _context.SaveChangesAsync(new CancellationToken());
    }

    public List<RoleDto> getAllRoleOfUser(string userId)
    {
        var result = new List<RoleDto>();
        var roleOfUser = _context.AspNetUserRoles.Where(c => c.UserId == userId).Select(x => x.RoleId).ToList();
        if (roleOfUser.Any())
        {
            result.AddRange(_context.AspNetRoles.Where(c => roleOfUser.Contains(c.Id))
                .ProjectTo<RoleDto>(_mapper.ConfigurationProvider).ToList());
        }
        return result;
    }

    public async Task<int> UpdateLockOut(string userId, bool LockOutState)
    {
        var user = _context.AspNetUsers.FirstOrDefault(c => c.Id == userId);
        if (user != null)
        {
            user.LockoutEnabled = LockOutState;
        }
        return await _context.SaveChangesAsync(new CancellationToken());
    }

    public async Task<int> DeleteUser(string userId)
    {
        var user = _context.AspNetUsers.FirstOrDefault(c => c.Id == userId);
        if (user != null)
        {
            _context.AspNetUsers.Remove(user);
        }
        return await _context.SaveChangesAsync(new CancellationToken());
    }

    public async Task<string> Create(UserDTO user)
    {
        var obj = _mapper.Map<AspNetUser>(user);
        obj.Id = Guid.NewGuid().ToString();
        _context.AspNetUsers.Add(obj);
        await _context.SaveChangesAsync(new CancellationToken());
        return obj.Id;
    }
    public async Task<string> Update(UserDTO user)
    {
        var obj = _mapper.Map<AspNetUser>(user);
        _context.AspNetUsers.Update(obj);
        await _context.SaveChangesAsync(new CancellationToken());
        return obj.Id;
    }

}
