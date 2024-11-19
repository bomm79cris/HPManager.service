using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Managers;
using HPManager.service.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var conectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conectionString).UseLazyLoadingProxies());
builder.Services.AddCors(options =>
    {
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   
              .AllowAnyMethod()   
              .AllowAnyHeader();  
   });
});
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
builder.Services.AddScoped<IUsuarioManager, UsuarioManager>();
builder.Services.AddScoped<IComportamientosManager,ComportamientosManager>();
builder.Services.AddScoped<ISesionesManager, SesionesManager>();
builder.Services.AddScoped<IRecomendacionesManager,RecomendacionesManager>();
//Repositories
builder.Services.AddScoped<ICitasRepository, CitasRepository>();
builder.Services.AddScoped<ITratamientosRepository, TratamientosRepository>();
builder.Services.AddScoped<IObservacionesRepository, ObservacionesRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IComportamientosRepository, ComportamientosRepository>();
builder.Services.AddScoped<ISesionesRepository,SesionRepository>();
builder.Services.AddScoped<IRecomendacionesRepository,RecomendacionesRepository>();

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
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.UseAuthentication();
app.UseCors("AllowAll"); 

app.MapControllers();

app.Run();
