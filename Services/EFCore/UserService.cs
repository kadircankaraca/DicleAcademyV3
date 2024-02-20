using AutoMapper;
using Entities.Models;
using Entities.ModelsDto;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.EFCore;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public List<UserForRegistrationDto> GetAllUsers()
    {
        var users = _repository.User.GenericRead(false);
        return _mapper.Map<List<UserForRegistrationDto>>(users);
    }

    public UserForRegistrationDto GetUserById(string id)
    {
        var user = _repository.User.GetUser(id, false);
        return _mapper.Map<UserForRegistrationDto>(user);
    }

    public UserForRegistrationDto CreateUser(UserForRegistrationDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        _repository.User.GenericCreate(user);
        _repository.Save();
        return _mapper.Map<UserForRegistrationDto>(user);
    }

    public void UpdateUser(UserForRegistrationDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        _repository.User.GenericUpdate(user);
        _repository.Save();
    }

    public void DeleteUser(string id)
    {
        var user = _repository.User.GetUser(id, false);
        if (user != null)
        {
            _repository.User.GenericDelete(user);
            _repository.Save();
        }
    }
}