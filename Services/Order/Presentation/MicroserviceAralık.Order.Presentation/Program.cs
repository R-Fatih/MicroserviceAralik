using MicroserviceAralýk.Order.Application.Services;
using MicroserviceAralýk.Order.Persistence.Configurations;
using MicroserviceAralýk.Order.Presentation.Consumer;
using MicroserviceAralýk.RabbitMQ.Abstract;
using MicroserviceAralýk.RabbitMQ.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "ResourceOrder";
    options.RequireHttpsMetadata = false;
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OrderReadAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "OrderReadPermission", "OrderFullPermission");
    });
    options.AddPolicy("OrderFullAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "OrderFullPermission");
    });
});
builder.Services.AddGenericServices();
builder.Services.AddMediator();
builder.Services.AddAutoMapper();

builder.Services.AddSingleton<IRabbitMQSubscriber>(sp => new RabbitMQSubscriber("localhost", "guest", "guest"));
builder.Services.AddSingleton<IRabbitMQPublisher>(sp => new RabbitMQPublisher("localhost", "guest", "guest"));
builder.Services.AddHostedService<OrderConsumer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
