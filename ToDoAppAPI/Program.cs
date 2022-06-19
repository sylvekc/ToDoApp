using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ToDoAppAPI;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Middleware;
using ToDoAppAPI.Models;
using ToDoAppAPI.Models.Validators;
using ToDoAppAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoAppDbConnection")));
builder.Services.AddScoped<Seeder>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ITaskGroupService, TaskGroupService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IValidator<TaskDto>, AddTaskDtoValidator>();
builder.Services.AddScoped<IValidator<TaskGroupDto>, TaskGroupDtoValidator>();
builder.Services.AddScoped<IValidator<UserDto>, AddUserDtoValidator>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEndClient", builder =>
        builder.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin()
        );
});

var app = builder.Build();
app.UseCors("FrontEndClient");
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
