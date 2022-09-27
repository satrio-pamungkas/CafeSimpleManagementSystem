using Microsoft.EntityFrameworkCore;
using CafeSimpleManagementSystem.Data;
using CafeSimpleManagementSystem.Repositories;
using CafeSimpleManagementSystem.Config;
using CafeSimpleManagementSystem.Services;
using CafeSimpleManagementSystem.Middlewares;
using CafeSimpleManagementSystem.Helpers;

var builder = WebApplication.CreateBuilder(args);
var DbString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(DbString));
builder.Services.AddScoped<ItemRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<JwtUtils>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandler>();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();
app.CreateDbIfNotExist();
app.Run();