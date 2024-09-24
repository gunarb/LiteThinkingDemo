using Application;
using Domain;
using InterfaceAdapters_Data;
using InterfaceAdapters_Mappers;
using InterfaceAdapters_Mappers.Dtos.Requests;
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
builder.Services.AddScoped<UpdateTaskItemUseCase<TaskItemEntity>>();
builder.Services.AddScoped<DeleteTaskItemUseCase<TaskItemEntity>>();

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
app.MapGet("/get-task-id", async (GetByIdUseCase<TaskItemEntity> taskItemUseCase, 
    int taskId) =>
{
    return await taskItemUseCase.ExecuteAsync(taskId);
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

// Mark a task as completed - TODO convert TaskItemEntity to TaskItem
app.MapPut("/update-status", async (UpdateTaskItemUseCase<TaskItemEntity> taskItemUseCase,
    int taskId, string newStatus) =>
{
    await taskItemUseCase.ExecuteAsync(taskId, newStatus);
    return Results.NoContent();
})
.WithName("updateTaskItem")
.WithOpenApi();

// Delete a task - TODO convert TaskItemEntity to TaskItem
// create a IPresenter to filter by a View Model instead of delete from DB
app.MapDelete("/delete-task-id", async (DeleteTaskItemUseCase<TaskItemEntity> taskItemUseCase, 
    int taskId) =>
{
    await taskItemUseCase.ExecuteAsync(taskId);
    return Results.NoContent();
})
.WithName("deleteTaskItem")
.WithOpenApi();

app.Run();
