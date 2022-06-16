using OrderManagement.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Mapster;
using System.Reflection;
using OrderManagement.Service.Contracts;
using OrderManagement.Service.Facades;
using OrderManagement.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

//Get Connection string 

builder.Configuration.AddJsonFile("appsettings.json", true, true);

var connectionString = builder.Configuration["Values:SqlConnectionString"];

builder.Services.AddDbContext<OrderManagementContext>(options =>
{
    if (connectionString != null)
    {
        options.UseSqlServer(connectionString, x => x.EnableRetryOnFailure()).EnableSensitiveDataLogging();
    }
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddSwaggerGen();

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

var app = builder.Build();



app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
