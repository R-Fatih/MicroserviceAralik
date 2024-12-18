using System.Reflection;
using MicroserviceAralýk.Message.Dal.Context;
using MicroserviceAralýk.Message.Services.MessageServices;
using MicroserviceAralýk.Message.Services.RabbitMqServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<RabbitMQPublisher>();
builder.Services.AddHostedService<RabbitMQConsumer>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
