using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Managers;
using HPManager.service.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var conectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conectionString).UseLazyLoadingProxies());

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
// Add services to the container.
//Managers
builder.Services.AddScoped<ICitasManager, CitasManager>();
builder.Services.AddScoped<ITratamientosManager, TratamientosManager>();
builder.Services.AddScoped<IObservacionesManager, ObservacionesManager>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
//Repositories
builder.Services.AddScoped<ICitasRepository, CitasRepository>();
builder.Services.AddScoped<ITratamientosRepository, TratamientosRepository>();
builder.Services.AddScoped<IObservacionesRepository, ObservacionesRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
