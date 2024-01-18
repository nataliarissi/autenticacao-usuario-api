using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserAuthenticationAPI.Services;
using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGroupServices, GroupServices>();
builder.Services.AddScoped<IPersonServices, PersonServices>();
builder.Services.AddScoped<IGroupServices, GroupServices>();

var connectionString = builder.Configuration.GetConnectionString("USERMANAGEMENT");
builder.Services.AddDbContext<AuthenticationDbContext>(options => options.UseSqlServer(connectionString));

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
