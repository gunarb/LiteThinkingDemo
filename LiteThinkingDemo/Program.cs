using Application;
using Domain;
using InterfaceAdapters_Data;
using InterfaceAdapters_Mappers;
using InterfaceAdapters_Mappers.Dtos.Requests;
using InterfaceAdapters_Models;
using InterfaceAdapters_Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ******** Dependencies ********
// Data base
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Interface Implementation - TODO convert TaskItemEntity to TaskItem
builder.Services.AddScoped<IRepository<TaskItemEntity>, TaskRepository>();
builder.Services.AddScoped<IMapper<TaskItemRequestDTO, TaskItemEntity>, TaskItemsMapper>();

// Use Cases - TODO convert TaskItemEntity to TaskItem
builder.Services.AddScoped<GetAllUseCase<TaskItemEntity>>();
builder.Services.AddScoped<GetByIdUseCase<TaskItemEntity>>();
builder.Services.AddScoped<AddTaskItemUseCase<TaskItemRequestDTO>>();

// ******** App ********
var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Get the list of all tasks - TODO convert TaskItemEntity to TaskItem
app.MapGet("/get-tasks", async (GetAllUseCase<TaskItemEntity> taskItemUseCase) =>
{
    return await taskItemUseCase.ExecuteAsync();
})
.WithName("tasks")
.WithOpenApi();

// Get a task by id - TODO convert TaskItemEntity to TaskItem
app.MapGet("/get-task-id", async (GetByIdUseCase<TaskItemEntity> taskItemUseCase, int id) =>
{
    return await taskItemUseCase.ExecuteAsync(id);
})
.WithName("task")
.WithOpenApi();

// Create a new task
app.MapPost("/new-task", async (TaskItemRequestDTO taskItemRequest,
    AddTaskItemUseCase<TaskItemRequestDTO> taskItemUseCase) =>
{
    await taskItemUseCase.ExecuteAsync(taskItemRequest);
    return Results.Created();
})
.WithName("addTaskItem")
.WithOpenApi();

// TODO mark a task as completed => a put method

// TODO delete a task => create a IPresenter to filter by a View Model

app.Run();
