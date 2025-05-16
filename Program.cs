using Microsoft.EntityFrameworkCore;
using myTasks.Services;
using MyTasks.Data;
using MyTasks.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<InterfaceUserService, UserService>();
//builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();
