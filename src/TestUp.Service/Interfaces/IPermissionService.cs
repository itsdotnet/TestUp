using TestUp.Service.DTOs.Permission;

namespace TestUp.Service.Interfaces;

public interface IPermissionService
{
    Task<bool> DeleteAsync(long id);
    Task<PermissionResultDto> GetByIdAsync(long id);
    Task<IEnumerable<PermissionResultDto>> GetAllAsync();
    Task<PermissionResultDto> ModifyAsync(PermissionUpdateDto permission);
    Task<PermissionResultDto> CreateAsync(PermissionCreationDto permission);
}