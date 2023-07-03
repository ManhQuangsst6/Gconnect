using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Mappings;
using Gconnect.Application.Common.Models;
using Gconnect.Application.DTO;
using Gconnect.Application.Interface;
using Gconnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gconnect.Infrastructure.Identity;

public class RoleServices : IRoleServices
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public RoleServices(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public void DeleteRole(string id)
    {
        var obj = _context.AspNetRoles.FirstOrDefault(c => c.Id == id);
        if (obj != null)
        {
            _context.AspNetRoles.Remove(obj);
            _context.SaveChangesAsync(new CancellationToken());
        }
    }

    public RoleDto? GetRole(string id)
    {
        var map = new Dictionary<string, string>();
        var obj = _context.AspNetRoles.FirstOrDefault(c => c.Id == id);
        if (obj != null)
        {
            return _mapper.Map<AspNetRole, RoleDto>(obj);
        }
        return null;
    }

    public async Task<PaginatedList<RoleDto>> GetRoles(string keySearch, int pageSize, int pageNumber)
    {
        var query = _context.AspNetRoles.AsNoTracking();
        if (!string.IsNullOrEmpty(keySearch))
        {
            query = query.Where(c => c.Name.Contains(keySearch));
        }
        var objs = await query.ProjectTo<RoleDto>(_mapper.ConfigurationProvider).PaginatedListAsync(pageNumber, pageSize);
        return objs;
    }
    public async Task<List<RoleDto>> GetAllRoles()
    {
        var query = _context.AspNetRoles.AsNoTracking();
        var objs = await query.ProjectTo<RoleDto>(_mapper.ConfigurationProvider).ToListAsync();
        return objs;
    }

    public string SaveRole(RoleDto role)
    {
        if (role != null)
        {
            // check trung ten
            if (_context.AspNetRoles.Any(c => c.Name.ToLower() == role.Name.ToLower()))
            {
                throw new InvalidOperationException(string.Format("Role with name {0} exited.", role.Name));
            }
            // luu role
            role.Id = Guid.NewGuid().ToString();
            var obj = _mapper.Map<AspNetRole>(role);
            _context.AspNetRoles.Add(obj);
            _context.SaveChangesAsync(new CancellationToken());
            return role.Id;
        }
        return string.Empty;
    }
    public void UpdateRole(RoleDto role)
    {
        if (role != null && !string.IsNullOrWhiteSpace(role.Id))
        {
            var obj = _context.AspNetRoles.SingleOrDefault(c => c.Id == role.Id);
            if (obj != null)
            {
                obj.Name = role.Name;
                obj.Description = role.Description;
                _context.SaveChangesAsync(new CancellationToken());
            }
        }
    }
}
