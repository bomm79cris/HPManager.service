using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Managers;
using HPManager.service.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using HPManager.service.Infrastructure.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

var conectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conectionString));
// Add services to the container.
//Managers
builder.Services.AddScoped<ICitasManager, CitasManager>();
builder.Services.AddScoped<ITratamientosManager, TratamientosManager>();
builder.Services.AddScoped<IObservacionesManager, ObservacionesManager>();
//Repositories
builder.Services.AddScoped<ICitasRepository, CitasRepository>();
builder.Services.AddScoped<ITratamientosRepository, TratamientosRepository>();
builder.Services.AddScoped<IObservacionesRepository, ObservacionesRepository>();

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

app.MapControllers();

app.Run();
