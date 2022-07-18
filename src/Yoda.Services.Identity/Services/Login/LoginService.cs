using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Yoda.Services.Identity.Data;
using Yoda.Services.Identity.Helpers;
using Yoda.Services.Login.Models;
using System.Security.Cryptography;

namespace Yoda.Services.Identity.Services.Login;

public class LoginService : ILoginService
{
    private readonly YodaContext _yodaContext;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public LoginService(YodaContext yodaContext, IMapper mapper, IOptions<AppSettings> appSettings)
    {
        _yodaContext = yodaContext;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    public async Task<JwtTokenModel> Login(CustomerModel customer)
    {
        var item = await _yodaContext.Customers
            .FirstOrDefaultAsync(x =>
                x.Username == customer.Username &&
                x.Password == customer.Password
            );
        if (item == null)
        {
            return new JwtTokenModel { };
        }
        var model = _mapper.Map<CustomerModel>(item);
        var token = GenerateJwtToken(model);
        return token;
    }

    private JwtTokenModel GenerateJwtToken(CustomerModel user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Jwt.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _appSettings.Jwt.Audience,
            Issuer = _appSettings.Jwt.Issuer,
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddMilliseconds(_appSettings.Jwt.TokenValidityInMilliSeconds),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new JwtTokenModel { Token = tokenHandler.WriteToken(token), Expire = token.ValidTo };
    }
}
