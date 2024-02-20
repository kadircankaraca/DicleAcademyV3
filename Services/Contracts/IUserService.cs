using Entities.ModelsDto;

namespace Services.Contracts
{
	public interface IUserService
	{
		List<UserForRegistrationDto> GetAllUsers();
        UserForRegistrationDto GetUserById(string id);
		UserForRegistrationDto CreateUser(UserForRegistrationDto userDto);
        void UpdateUser(UserForRegistrationDto userDto);
        void DeleteUser(string id);
    }
}

