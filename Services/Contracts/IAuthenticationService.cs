
using Entities.ModelsDto;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
	public interface IAuthenticationService
	{
        //Kullanıcı kayıt imzası
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        //Kullanıcı doğrulama işlemi
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto);
        //Tokken oluşturma metodu
        Task<TokenDto> CreateToken(bool populateExp);
        //Token Yenileme metodu
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}

