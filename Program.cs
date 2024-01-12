using cmcmarketsbetask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Logging.AddLog4Net();

// Add services to the container.

builder.Services.AddControllers();
//configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Depency Injection of DbContext Class

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConn")));

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
