using Microsoft.EntityFrameworkCore;
using Todolist;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ModelDbContext>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
