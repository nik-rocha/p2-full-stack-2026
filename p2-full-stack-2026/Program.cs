using Microsoft.EntityFrameworkCore;
using p2_full_stack_2026.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string mySqlConnection = builder.Configuration.GetConnectionString("Iniciar");
builder.Services.AddDbContext<ContextDB>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection))
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
