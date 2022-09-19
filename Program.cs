using Microsoft.EntityFrameworkCore;
using CafeSimpleManagementSystem.Data;
using CafeSimpleManagementSystem.Repositories;

var builder = WebApplication.CreateBuilder(args);
var DbString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(DbString));
builder.Services.AddScoped<ItemRepository>();

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
app.CreateDbIfNotExist();
app.Run();