using Microsoft.EntityFrameworkCore;
using NETBase.Data;
using NETBase.Interfaces.IRepositories;
using NETBase.Interfaces.IServices;
using NETBase.Repositories;
using NETBase.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DATABASE CONN
builder.Services.AddDbContext<DataDBContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")));

// SERVICES
builder.Services.AddTransient<IUserService, UserService>();

// REPOSITORIES
builder.Services.AddTransient<IUserRepository, UserRepository>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ENSURE THAT DATABASE IS CREATED IF NOT CREATE IT
using (var scope = app.Services.CreateScope())
{
    var Context = scope.ServiceProvider.GetRequiredService<DataDBContext>();
    Context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
