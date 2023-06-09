using Pos.Aplicacion.Extensiones;
using Pos.Infraestructura.Extensiones;

var builder = WebApplication.CreateBuilder(args);
var configuracionCapasInyeccion = builder.Configuration;

// Add services to the container.
builder.Services.AgregarInyeccionInfraestructura(configuracionCapasInyeccion);
builder.Services.AgregarInyeccionAplicacion(configuracionCapasInyeccion);

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

public partial class Program { }
