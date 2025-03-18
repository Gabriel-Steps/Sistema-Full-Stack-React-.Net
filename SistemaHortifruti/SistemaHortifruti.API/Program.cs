using Microsoft.EntityFrameworkCore;
using SistemaHortifruti.Infrastructure.Persistence;
using SistemaHortifruti.Application.Queries.GetAllFrutas;
using SistemaHortifruti.Application.Commands.CreateFruta;
using SistemaHortifruti.Application.Commands.UpdateFruta;
using SistemaHortifruti.Application.Commands.DeleteFruta;
using SistemaHortifruti.Application.Queries.GetByIdUsuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SistemaHortifrutiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do CORS, permição para a página frontend consumir a API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

#region declaracao_mediators
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllFrutasQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateFrutaCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateFrutaCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteFrutaCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetByIdUsuarioQueryHandler).Assembly));
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
