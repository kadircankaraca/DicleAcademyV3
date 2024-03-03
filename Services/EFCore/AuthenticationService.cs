using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Entities.Exception;
using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;

namespace Services.EFCore;

public class AuthenticationService : IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;

    private User? _user;

    public AuthenticationService(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
    {
        _mapper = mapper;
        _configuration = configuration;
        _userManager = userManager;

    }

    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto registrationUser)
    {
        try
        {
            var user = _mapper.Map<User>(registrationUser);
            var result = await _userManager.CreateAsync(user, registrationUser.Password);

            if (result.Succeeded) await _userManager.AddToRolesAsync(user, registrationUser.Roles);
            return result;
        }
        catch(Exception e) 
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    //public async Task<UserForGetDto> GetUser(string id)
    //{
    //    UserForGetDto myUser = new UserForGetDto();
    //    User myUser1 = await _userManager.FindByIdAsync(id);


    //    myUser.PhoneNumber = myUser1.PhoneNumber;
    //    myUser.FirstName = myUser1.FirstName;
    //    myUser.LastName = myUser1.LastName;
    //    myUser.Email = myUser1.Email;

    //    return myUser;
    //}



    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthDto)
    {
        _user = await _userManager.FindByNameAsync(userForAuthDto.UserName);
        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthDto.Password));
        if (!result) Console.WriteLine("Kullanıcı adı veya şifre hatalıdır.");
        return result;
    }

    public async Task<TokenDto> CreateToken(bool populateExp)
    {
        var signinCredentials = GetSigninCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

        var refreshToken = GenerateRefreshToken();
        _user.RefreshToken = refreshToken;

        if (populateExp) _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

        await _userManager.UpdateAsync(_user);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return new TokenDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }


    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["ValidateIssue"],
            audience: jwtSettings["ValidateAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToInt32(jwtSettings["Expire"])),
            signingCredentials: signinCredentials);
        return tokenOptions;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

        var roles = await _userManager
            .GetRolesAsync(_user);

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    private SigningCredentials GetSigninCredentials()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
    {
        var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
        var user = await _userManager.FindByNameAsync(principal.Identity.Name);

        //await Microsoft.AspNetCore.Authentication.HttpContext.SignInAsync();

        if (user is null ||
            user.RefreshToken != tokenDto.RefreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.Now)

            throw new RefreshTokenBadRequestException();

        _user = user;
        return await CreateToken(populateExp: false);
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["ValidateIssue"],
            ValidAudience = jwtSettings["ValidateAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters,
            out securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken; //as gibi davranmasını sağlar(Başarısız olma durumunda null gelecek)
        if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token.");
        }
        return principal;
    }

    public List<User> GetAllUsers()
    {
        List<User> myUser1 = _userManager.Users.ToList();

        return myUser1;
    }
}