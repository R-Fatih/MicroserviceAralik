using MicroserviceAralık.Image.Context;
using MicroserviceAralık.Image.Services;
using MicroserviceAralık.Image.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AWSSettings>(builder.Configuration.GetSection(nameof(AWSSettings)));
builder.Services.AddDbContext<ImageContext>();
builder.Services.AddScoped<IFileUploader, FileUploader>();

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
