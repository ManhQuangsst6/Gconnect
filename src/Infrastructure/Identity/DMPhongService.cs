using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Mappings;
using Gconnect.Application.Common.Models;
using Gconnect.Application.DTO;
using Gconnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gconnect.Infrastructure.Identity;
public class DMPhongService : IDMPhongService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DMPhongService(
        IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<string> Create(DMPhongDTO department)
    {
        var obj = _mapper.Map<DmPhong>(department);
        obj.Id = Guid.NewGuid().ToString();
        _context.DmPhongs.Add(obj);
        await _context.SaveChangesAsync(new CancellationToken());
        return obj.Id;
    }

    public async Task<Result> DeleteDepartmentAsync(string departmentId)
    {
        var obj = _context.DmPhongs.SingleOrDefault(item => item.Id.Equals(departmentId));
        try
        {
            _context.DmPhongs.Remove(obj);
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

    public async Task<Result> DeleteDepartmentByNameAsync(string departmentName)
    {
        var obj = _context.DmPhongs.SingleOrDefault(item => item.Id.Equals(departmentName));
        try
        {
            _context.DmPhongs.Remove(obj);
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

    public async Task<PaginatedList<DMPhongDTO>> getAllPaging(string keySearch, int pageNumber, int pageSize)
    {
        var query = _context.DmPhongs.AsNoTracking();
        if (!string.IsNullOrEmpty(keySearch))
        {
            query = query.Where(c => c.TenPhong.Contains(keySearch));
        }
        var objs = await query.ProjectTo<DMPhongDTO>(_mapper.ConfigurationProvider).PaginatedListAsync(pageNumber, pageSize);
        return objs;
    }

    public async Task<DMPhongDTO> GetById(string departmentId)
    {
        var obj = _context.DmPhongs.SingleOrDefault(x => x.Id.Equals(departmentId));
        return _mapper.Map<DMPhongDTO>(obj);
    }

    public async Task<DMPhongDTO> GetDepartmentNameAsync(string departmentName)
    {

        var obj = _context.DmPhongs.SingleOrDefault(x => x.TenPhong.Equals(departmentName));
        return _mapper.Map<DMPhongDTO>(obj);
    }

    public Task<(Result Result, string DepartmentID)> UpdateDepartmentAsync(string departmentName)
    {
        throw new NotImplementedException();
    }
}
