using AutoMapper;
using TestUp.Service.Interfaces;
using TestUp.Service.Exceptions;
using TestUp.DataAccess.IRepositories;
using TestUp.Service.DTOs.Permission;

namespace TestUp.Service.Services;
#pragma warning disable CS1998

public class PermissionService : IPermissionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PermissionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var permission = await _unitOfWork.PermissionRepository.SelectAsync(x => x.Id == id);

        if (permission is null)
            throw new NotFoundException("Answer not found");

        await _unitOfWork.PermissionRepository.DeleteAsync(x => x == permission);
        return await _unitOfWork.SaveAsync();
    }

    public async Task<PermissionResultDto> GetByIdAsync(long id)
    {
        var permission = await _unitOfWork.PermissionRepository.SelectAsync(q => q.Id == id);

        if (permission is null)
            throw new NotFoundException("Permission not found");

        return _mapper.Map<PermissionResultDto>(permission);
    }

    public async Task<IEnumerable<PermissionResultDto>> GetAllAsync()
    {
        var permissions = _unitOfWork.PermissionRepository.SelectAll();

        return _mapper.Map<IEnumerable<PermissionResultDto>>(permissions);
    }

    public async Task<PermissionResultDto> ModifyAsync(PermissionUpdateDto permission)
    {
        var exist = await _unitOfWork.PermissionRepository.SelectAsync(q => q.Id == permission.Id);

        if (exist is null)
            throw new NotFoundException("Question not found");

        _mapper.Map(permission, exist);

        await _unitOfWork.SaveAsync();

        return _mapper.Map<PermissionResultDto>(exist);
    }

    public async Task<PermissionResultDto> CreateAsync(PermissionCreationDto permission)
    {
        var permissions = _unitOfWork.PermissionRepository.SelectAll();

        foreach (var i in permissions)
        {
            if (i.Create == permission.Create && i.Get == permission.Get && i.Update == permission.Update && i.Delete == permission.Delete)
                throw new AlreadyExistException("Already exist");
        }

        var mapped = _mapper.Map<Permission>(permission);

        await _unitOfWork.PermissionRepository.AddAsync(mapped);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<PermissionResultDto>(mapped);
    }
}