using AutoMapper;
using TestUp.Service.Helpers;
using TestUp.Service.DTOs.User;
using TestUp.Service.Exceptions;
using TestUp.Service.Interfaces;
using TestUp.Service.DTOs.Permission;
using TestUp.DataAccess.IRepositories;

namespace TestUp.Service.Services;
    #pragma warning disable CS1998

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserResultDto> ChangePermissions(long Id, PermissionCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CheckUserAsync(string emailOrUsername, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResultDto> CreateAsync(UserCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await _unitOfWork.UserRepository.SelectAsync(q => q.Id == id);

        if (user is null)
            throw new NotFoundException("User not found");

        await _unitOfWork.UserRepository.DeleteAsync(x => x == user);
        return await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<UserResultDto>> GetAllAsync()
    {
        var users = _unitOfWork.UserRepository.SelectAll();

        return _mapper.Map<IEnumerable<UserResultDto>>(users);
    }

    public async Task<UserResultDto> GetByEmailAsync(string email)
    {
        var user = await _unitOfWork.UserRepository.SelectAsync(q => q.Email == email);

        if (user is null)
            throw new NotFoundException("User not found");

        return _mapper.Map<UserResultDto>(user);
    }

    public async Task<UserResultDto> GetByIdAsync(long id)
    {
        var user = await _unitOfWork.UserRepository.SelectAsync(q => q.Id == id);

        if (user is null)
            throw new NotFoundException("User not found");

        return _mapper.Map<UserResultDto>(user);
    }

    public Task<IEnumerable<UserResultDto>> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserResultDto>> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        var exist = await _unitOfWork.UserRepository.SelectAsync(q => q.Username == dto.Username);

        if (exist is null)
            throw new NotFoundException("User not found");

        _mapper.Map(dto, exist);

        await _unitOfWork.UserRepository.UpdateAsync(exist);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResultDto>(exist);
    }

    public async Task<UserResultDto> ModifyPasswordAsync(long id, string oldPass, string newPass)
    {
        var exist = await _unitOfWork.UserRepository.SelectAsync(q => q.Id == id);

        if (exist is null)
            throw new NotFoundException("User not found");

        if (oldPass.Verify(exist.Password))
            throw new CustomException(403, "Passwor is invalid");

        exist.Password = newPass.Hash();
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResultDto>(exist);
    }
}