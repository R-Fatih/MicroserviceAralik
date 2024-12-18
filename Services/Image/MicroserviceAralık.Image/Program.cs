using MicroserviceAralýk.Image.Context;
using MicroserviceAralýk.Image.Services;
using MicroserviceAralýk.Image.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "ResourceImage";
    options.RequireHttpsMetadata = false;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ImageFullAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "ImageFullPermission");
    });
    options.AddPolicy("ImageReadAccess", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "ImageReadPermission", "ImageFullPermission");
    });
});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
