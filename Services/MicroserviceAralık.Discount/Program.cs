using MicroserviceAralýk.Discount.Context;
using MicroserviceAralýk.Discount.Mappings;
using MicroserviceAralýk.Discount.Services;
using MicroserviceAralýk.Discount.Services.CouponServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDiscountCouponService, DiscountCouponService>();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));

builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CouponsService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
