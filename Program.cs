using FirstProject;
using FirstProject.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using MediatR;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddControllers();
builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();

//builder.Services.AddControllers().AddNewtonSoft.json();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UsersdbContext>(option=> option.UseNpgsql(builder.Configuration.GetConnectionString("connection")));
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
