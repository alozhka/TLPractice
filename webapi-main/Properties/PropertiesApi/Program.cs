using Domain.Repositories;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Scoped нужен для одного соединения к БД в рамках одного запроса
builder.Services.AddScoped<IPropertiesRepository, PropertiesRepository>();
builder.Services.AddDbContext<PropertiesDbContext>(cfg =>
{
    cfg.UseInMemoryDatabase(databaseName: "Properties");
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();