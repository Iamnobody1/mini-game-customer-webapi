using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Yoda.Services.Identity.Data;
using Yoda.Services.Identity.Helpers;
using Yoda.Services.Login.Models;

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

    public async Task<string> Login(CustomerModel customer)
    {
        var item = await _yodaContext.Customers
            .FirstOrDefaultAsync(x =>
                x.Username == customer.Username &&
                x.Password == customer.Password
            );
        var token = generateJwtToken(customer);
        if (item == null)
        {
            return string.Empty;
        }
        return token;
    }

    private string generateJwtToken(CustomerModel user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
