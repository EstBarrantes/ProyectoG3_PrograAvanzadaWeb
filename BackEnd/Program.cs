using BackEnd.DTO;
using BackEnd.Services.implementations;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI


builder.Services.AddDbContext<G3prograavanzadaContext>(optionsAction =>
                    optionsAction
                    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

    );


builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<IRolDAL, RolDAL>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<ICategoriaDAL, CategoriaDAL>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IUsuarioDAL, UsuarioDAL>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
#endregion


var app = builder.Build();// hasta aqui me indica error

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
