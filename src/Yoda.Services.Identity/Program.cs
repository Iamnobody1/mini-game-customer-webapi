using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Yoda.Services.Identity.Data;
using Yoda.Services.Identity.Helpers;
using Yoda.Services.Identity.Services.Login;

var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
builder.Services.Configure<AppSettings>((builder.Configuration.GetSection(nameof(AppSettings))));
var allowedOrigins = builder.Configuration["AllowedOrigins"];
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        nameof(allowedOrigins),
        policy =>
        {
            policy.WithOrigins(allowedOrigins.Split(';'))
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
    );
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        options.SerializerSettings.DateFormatString = builder.Configuration.GetValue<String>("DateFormatString");
    });
builder.Services.AddMvc();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddDbContext<YodaContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Yoda")));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = appSettings.Jwt.Audience,
        ValidIssuer = appSettings.Jwt.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Jwt.Secret))
    };
});

var app = builder.Build();
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(nameof(allowedOrigins));
app.Run();
