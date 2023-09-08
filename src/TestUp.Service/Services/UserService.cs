using AutoMapper;
using TestUp.Service.Helpers;
using TestUp.Service.DTOs.User;
using TestUp.Service.Exceptions;
using TestUp.Service.Interfaces;
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

    public async Task<bool> CheckUserAsync(string emailOrUsername, string password)
    {
        var user = await _unitOfWork.UserRepository.SelectAsync(x => x.Email == emailOrUsername || x.Username == emailOrUsername);
        if (password.Verify(user.Password)) // will be change to validator
        {
            return true;
        }
        return false;
    }

    public async Task<UserResultDto> CreateAsync(UserCreationDto dto)
    {
        dto.Username = dto.Username.Trim().ToLower();
        var exist = await _unitOfWork.UserRepository.SelectAsync(q => q.Username == dto.Username || q.Email == dto.Email);

        if (exist is not null)
            throw new AlreadyExistException("User already exist with this Username");
        if(dto.AttachmentId != 0)
        {
            var attachment = await _unitOfWork.AttachmentRepository.SelectAsync(x => x.Id == dto.AttachmentId);
            if (attachment is null)
                throw new NotFoundException("Attachment not found");
        }
        else
        {
            dto.AttachmentId = null;
        }

        var newUser = _mapper.Map<User>(dto);
        newUser.Password = PasswordHasher.Hash(newUser.Password);
        await _unitOfWork.UserRepository.AddAsync(newUser);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<UserResultDto>(newUser);
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

    public async Task<IEnumerable<UserResultDto>> GetByName(string name)
    {
        var users = _unitOfWork.UserRepository.SelectAll(u =>
            u.Firstname.Contains(name) || u.Lastname.Contains(name));

        return _mapper.Map<IEnumerable<UserResultDto>>(users);
    }

    public async Task<IEnumerable<UserResultDto>> GetByUsernameAsync(string username)
    {
        var users = _unitOfWork.UserRepository
            .SelectAll(u => u.Username.StartsWith(username.ToLower().Trim()));

        return _mapper.Map<IEnumerable<UserResultDto>>(users);
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        dto.Username = dto.Username.Trim().ToLower();

        var exist = await _unitOfWork.UserRepository.SelectAsync(d => d.Id == dto.Id);

        if (exist is null)
            throw new NotFoundException("User not found");

        if (exist.Username != dto.Username)
        {
            var existUser = await _unitOfWork.UserRepository.SelectAsync(d => d.Username == dto.Username);
            if (existUser is not null)
                throw new AlreadyExistException("User already exist with this Username");
        }


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