using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UserAuthenticationAPI.Services.Implementations;
using UserAuthenticationAPI.Services.Interfaces;
using UserAuthenticationAPI.UserDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGroupsService, GroupsService>();
builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddDbContext<AuthenticationDbContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AuthenticationDbContext>();

    context.Database.EnsureCreated();
}

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
