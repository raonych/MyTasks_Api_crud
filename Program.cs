using Microsoft.EntityFrameworkCore;
using MyTasks.Data;
using MyTasks.Interfaces;
using MyTasks.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<InterfaceUserService, UserService>();
builder.Services.AddScoped<InterfaceTodoService, TodoService>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();
