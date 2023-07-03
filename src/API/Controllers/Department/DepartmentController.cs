using Gconnect.API.Common;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Application.Common.Models;
using Gconnect.Application.CQRS.QuanLyTaiKhoan.Queries;
using Gconnect.Application.DTO;
using Microsoft.AspNetCore.Mvc;
namespace Gconnect.API.Controllers.Department;

[Route("api/[controller]/[action]")]
public class DepartmentController : ApiControllerBase
{
    private readonly IDMPhongService _dhongService;

    public DepartmentController(IDMPhongService dhongService)
    {
        _dhongService = dhongService;
    }

    [HttpPost]
    public async Task<ApiResponse<string>> Create(DMPhongDTO dMPhongDTO)
    {
        var response = new ApiResponse<string>();
        response.Result = await _dhongService.Create(dMPhongDTO);
        return response;
    }
    [HttpGet]
    public async Task<ApiResponse<PaginatedList<DMPhongDTO>>> GetPage([FromQuery] GetQuanLyTaiKhoanPaging query)
    {
        var response = new ApiResponse<PaginatedList<DMPhongDTO>>();
        response.Result = await _dhongService.getAllPaging(query.KeySearch, query.PageNumber, query.PageSize);
        return response;
    }
    [HttpDelete]
    public async Task<ApiResponse<Result>> DeleteByID(string departmentID)
    {
        var response = new ApiResponse<Result>();
        response.Result = await _dhongService.DeleteDepartmentAsync(departmentID);
        return response;
    }

}
