using System;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



//Area de servicios

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=Movements.db"));

builder.Services.AddScoped<IMovementsRepository, MovementsRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Movements API",
        Version = "v1"
    });
});


var app = builder.Build();


// Asegura que la base de datos se cree y se aplique el Seed Data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

//Area de middlewares

//Habilita Swagger
app.UseSwagger();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty;
    });
}


app.MapControllers(); //Middleware de controladores

app.Run();

