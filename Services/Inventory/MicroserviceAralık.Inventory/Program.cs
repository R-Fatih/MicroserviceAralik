using MicroserviceAralık.Inventory.Consumers;
using MicroserviceAralık.Inventory.Context;
using MicroserviceAralık.Inventory.Services.StockServices;
using MicroserviceAralık.Inventory.Services.WarehouseServices;
using MicroserviceAralık.RabbitMQ.Abstract;
using MicroserviceAralık.RabbitMQ.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();

builder.Services.AddSingleton<IRabbitMQPublisher>(sp => new RabbitMQPublisher("localhost", "guest", "guest"));
builder.Services.AddSingleton<IRabbitMQSubscriber>(sp => new RabbitMQSubscriber("localhost", "guest", "guest"));
builder.Services.AddHostedService<InventoryConsumer>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
